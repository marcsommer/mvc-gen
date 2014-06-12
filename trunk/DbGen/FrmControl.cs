using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;
using DbGen.SplashForm;
using DbGenLibrary.SchemaExtend;
using DbGenLibrary.SolutionGen;
using DbGenLibrary.SolutionGen.BusinessLogic;
using DbGenLibrary.SQL;
using DbGenLibrary.SqlSchema;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace DbGen
{
    public partial class FrmControl : XtraForm
    {
        private readonly SqlServer _server;

        public FrmControl()
        {
            InitializeComponent();
        }

        public FrmControl(SqlConnectionStringBuilder connectionStringBuilder)
            : this()
        {
            _server = new SqlServer(connectionStringBuilder);
            RefreshDbList();
            txtAuthor.Text = Environment.UserName;
            txtTargetFolder.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\output";

        }
        private void RefreshDbList()
        {
            var dataSource = _server.Databases();
            cmbDatabases.Properties.Items.Clear();
            cmbDatabases.Properties.Items.AddRange(dataSource);
        }

        private void frmChinh_Load(object sender, EventArgs e)
        {
            InitGenType();
        }

        private void btnRefreshDbList_Click(object sender, EventArgs e)
        {
            RefreshDbList();
        }

        private GenInfo _genInfo;
        private void cmbDatabases_SelectedIndexChanged(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(SplashScreenLoading));
            try
            {
                _server.Builder.InitialCatalog = cmbDatabases.SelectedText;
                _genInfo = _server.GetFullTableInfomation();
                _genInfo.SetName(cmbDatabases.SelectedText);
                _genInfo.ConnectionString = _server.Builder.ConnectionString;
                gridControlTables.DataSource = _genInfo.Tables;
                gridViewTables.BestFitColumns();
                txtNameSpace.Text = txtTitle.Text = _genInfo.NameSpace;

            }
            catch (Exception exception)
            {
                XtraMessageBox.Show(exception.Message);
            }
            SplashScreenManager.CloseForm();
        }

        public MapTable GetSelectedTable()
        {
            var i = gridViewTables.GetSelectedRows()[0];
            var obj = gridViewTables.GetRow(i) as MapTable;
            return obj;
        }

        private void gridViewTables_Click(object sender, EventArgs e)
        {
            if (gridViewTables.SelectedRowsCount == 1)
            {
                try
                {
                    var table = GetSelectedTable();
                    var dataSource = table.Columns;
                    gridControlColumns.DataSource = dataSource;
                    gridViewColumns.BestFitColumns();
                }
                catch (Exception exception)
                {
                    XtraMessageBox.Show(exception.Message);
                }
            }
        }

        private void btnSelectTargetFolder_Click(object sender, EventArgs e)
        {
            if (dialogTargetFolder.ShowDialog() == DialogResult.OK)
            {
                txtTargetFolder.ToolTip = txtTargetFolder.Text = dialogTargetFolder.SelectedPath;
            }
        }

        private void iAbout_ItemClick(object sender, ItemClickEventArgs e)
        {
            var f = new FrmAbout();
            f.ShowDialog();
        }

        private void rdGenType_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitGenType();
        }

        private void InitGenType()
        {
            switch (GenType)
            {
                case GenType.LibraryOnly:
                    colDisplayTextForTable.Visible = false;
                    colDisplayTextForColumn.Visible = false;
                    colDisplayColumn.Visible = false;
                    colDisplayTable.Visible = false;

                    break;
                case GenType.MvcSolution:
                    colDisplayTextForTable.Visible = true;
                    colDisplayTextForColumn.Visible = true;
                    colDisplayColumn.Visible = true;
                    colDisplayTable.Visible = true;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        GenType GenType
        {
            get
            {
                return (GenType)Enum.Parse(typeof(GenType), rdGenType.EditValue.ToString(), true);
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            UpdateGenInfo();
            switch (GenType)
            {
                case GenType.LibraryOnly:
                    GenLibraryOnly();
                    break;
                case GenType.MvcSolution:
                    GenMvcSolution();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        void UpdateGenInfo()
        {
            try
            {
                _genInfo.PageSize = tbPageSize.Value;
                _genInfo.ProjectTitle = string.IsNullOrWhiteSpace(txtTitle.Text) ? _genInfo.DbName : txtTitle.Text;
                _genInfo.NameSpace = string.IsNullOrWhiteSpace(txtNameSpace.Text) ? _genInfo.DbName : txtNameSpace.Text;
                _genInfo.Author = string.IsNullOrWhiteSpace(txtAuthor.Text) ? "Microsoft ASP.NET MVC" : txtAuthor.Text;
            }
            catch
            {

            }

        }


        void GenLibraryOnly()
        {
            try
            {
                if (_genInfo == null)
                    throw new Exception("Xin vui lòng chọn cơ sở dữ liệu!");
                var folder = GenController.GenBusinessLogic(_genInfo);
                folder.Write(txtTargetFolder.Text);
                if (XtraMessageBox.Show("Bạn có muốn mở thư mục vừa được sinh ra?", "Hoàn tất", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    Process.Start(string.Format("{0}\\{1}", txtTargetFolder.Text, folder.Name));

            }
            catch (Exception exception)
            {
                XtraMessageBox.Show(exception.Message);
            }

        }
        void GenMvcSolution()
        {
            try
            {
                if (_genInfo == null)
                    throw new Exception("Xin vui lòng chọn cơ sở dữ liệu!");

                var folder = GenController.GenMvcSolution(_genInfo);
                folder.Write(txtTargetFolder.Text);
                if (XtraMessageBox.Show("Bạn có muốn mở thư mục vừa được sinh ra?", "Hoàn tất", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    Process.Start(string.Format("{0}\\{1}", txtTargetFolder.Text, folder.Name));

            }
            catch (Exception exception)
            {
                XtraMessageBox.Show(exception.Message);
            }

        }


    }
}