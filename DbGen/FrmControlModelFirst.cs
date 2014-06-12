using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using DbGen.ModelForm;
using DbGen.SplashForm;
using DbGenLibrary.IO;
using DbGenLibrary.SchemaExtend;
using DbGenLibrary.SolutionGen;
using DbGenLibrary.SqlSchema;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraSplashScreen;

namespace DbGen
{
    public partial class FrmControlModelFirst : XtraForm
    {
        private readonly GenInfo _genInfo = new GenInfo();
        private readonly SqlServer _server;
        private SqlConnectionStringBuilder _builder;

        public FrmControlModelFirst()
        {
            InitializeComponent();
        }

        private GenType GenType
        {
            get { return (GenType) Enum.Parse(typeof (GenType), rdGenType.EditValue.ToString(), true); }
        }


        private void frmChinh_Load(object sender, EventArgs e)
        {
            txtAuthor.Text = Environment.UserName;
            txtTargetFolder.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\output";
            txtNameSpace.Text = "MyNamespace";
        }

        private string GetConnectionString(string dbName, SqlConnectionStringBuilder builder)
        {
            SqlConnectionStringBuilder b;
            if (builder == null)
            {
                b = new SqlConnectionStringBuilder();
                b.IntegratedSecurity = true;
                b.DataSource = "(local)";
            }
            else
            {
                b = new SqlConnectionStringBuilder(builder.ConnectionString);
            }
            b.InitialCatalog = txtNameSpace.Text;
            return b.ConnectionString;
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


        private void btnExecute_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(typeof (SplashScreenLoading));
            try
            {
                UpdateGenInfo();
                ProjectFolder folder;
                switch (GenType)
                {
                    case GenType.LibraryOnly:
                        folder = GenController.GenBusinessLogic(_genInfo);
                        break;
                    case GenType.MvcSolution:
                        folder = GenMvcSolution();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }


                TextFile sql = GenController.GenSqlScript(_genInfo);
                if (ceSql.Checked)
                    folder.Files.Add(sql);
                if (ceExcecute.Checked)
                {
                    var server = new SqlServer(_builder);
                    server.ExecuteSql(sql.Text);
                }

                folder.Write(txtTargetFolder.Text);

                if (XtraMessageBox.Show("Bạn có muốn mở thư mục vừa được sinh ra?", "Hoàn tất", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    Process.Start(string.Format("{0}\\{1}", txtTargetFolder.Text, folder.Name));
            }
            catch (Exception exception)
            {
                XtraMessageBox.Show(exception.Message);
            }
            finally
            {
                SplashScreenManager.CloseForm();
            }
        }

        private void UpdateGenInfo()
        {
            try
            {
                _genInfo.PageSize = tbPageSize.Value;
                _genInfo.DbName = txtNameSpace.Text;

                _genInfo.ProjectTitle = string.IsNullOrWhiteSpace(txtTitle.Text) ? _genInfo.DbName : txtTitle.Text;
                _genInfo.NameSpace = string.IsNullOrWhiteSpace(txtNameSpace.Text) ? _genInfo.DbName : txtNameSpace.Text;
                _genInfo.Author = string.IsNullOrWhiteSpace(txtAuthor.Text) ? "Microsoft ASP.NET MVC" : txtAuthor.Text;

                _genInfo.ConnectionString = GetConnectionString(_genInfo.DbName, _builder);

                _genInfo.Tables = MdiChildren.OfType<FrmObject>().Select(f =>
                {
                    f.Columns.ForEach(c =>
                    {
                        c.Display = !c.IsPrimaryKey;
                        c.IsIdentity = c.IsPrimaryKey && c.Type.Equals("int", StringComparison.OrdinalIgnoreCase);
                    });
                    return new MapTable
                    {
                        TableName = f.Text,
                        Columns = f.Columns.ToList(),
                    };
                }).ToList();
            }
            catch
            {
            }
        }


        private ProjectFolder GenMvcSolution()
        {
            return GenController.GenMvcSolution(_genInfo);
        }

        private void btnAddTable_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            var fName = new FrmObjectName(string.Format("Object{0}", MdiChildren.Length + 1));
            if (fName.ShowDialog() == DialogResult.OK)
            {
                var f = new FrmObject
                {
                    MdiParent = this,
                    Text = fName.ObjName
                };
                f.Show();
            }
        }

        private void btnCascade_ItemClick(object sender, ItemClickEventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void btnMimize_ItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                child.WindowState = FormWindowState.Minimized;
            }
        }

        private void btnEdit_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Form f = ActiveMdiChild;
            if (f != null)
            {
                var name = new FrmObjectName(f.Text);
                if (name.ShowDialog() == DialogResult.OK)
                {
                    f.Text = name.ObjName;
                }
            }
        }

        private void btnDelete_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            Form f = ActiveMdiChild;
            if (f != null)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa " + f.Text, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                f.Close();
            }
        }

        private void btnDeleteAll_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            if (MdiChildren.Length > 0)
            {
                if (XtraMessageBox.Show("Bạn có muốn xóa tất cả " + MdiChildren.Length + " đối tượng ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                MdiChildren.ForEach(f => f.Close());
            }
        }

        private void btnShowAll_ItemClick(object sender, ItemClickEventArgs e)
        {
            MdiChildren.ForEach(f => f.WindowState = FormWindowState.Normal);
        }

        private void ceExcecute_Click(object sender, EventArgs e)
        {
            if (_builder == null)
            {
                var f = new FrmConfig();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    _builder = f.SqlConnectionStringBuilder;
                    ceExcecute.Checked = true;
                }
                else
                {
                    ceExcecute.Checked = false;
                }
            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            var f = new FrmConfig();
            if (f.ShowDialog() == DialogResult.OK)
            {
                _builder = f.SqlConnectionStringBuilder;
                ceExcecute.Checked = true;
            }
        }

        private void rdGenType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (rdGenType.EditValue as string)
            {
                case "LibraryOnly":
                    txtAuthor.Enabled = false;
                    txtTitle.Enabled = false;
                    tbPageSize.Enabled = false;
                    break;

                case "MvcSolution":
                    txtAuthor.Enabled = true;
                    txtTitle.Enabled = true;
                    tbPageSize.Enabled = true;
                    break;
                default:
                    break;
            }
        }

        private void iExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }
    }
}