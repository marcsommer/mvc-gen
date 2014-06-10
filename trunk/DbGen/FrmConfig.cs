using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using DbGen.SplashForm;
using DbGenLibrary.SQL;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;

namespace DbGen
{
    public partial class FrmConfig : XtraForm
    {
        public FrmConfig()
        {
            InitializeComponent();
            SetStyle();
            GetAllInstances();
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            var connection = TestConnection();
            XtraMessageBox.Show(connection ? "Kết nối thành công" : "Kết nối thất bại");
        }

        bool TestConnection()
        {
            SplashScreenManager.ShowForm(typeof(SplashScreenLoading));
            var connection = SqlServer.TestConnection(SqlConnectionStringBuilder.ConnectionString);
            SplashScreenManager.CloseForm();
            return connection;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var connection = TestConnection();
            if (!connection)
                XtraMessageBox.Show("Kết nối thất bại");
            else
                DialogResult = DialogResult.OK;
        }

        public SqlConnectionStringBuilder SqlConnectionStringBuilder
        {
            get
            {
                var sBuilder = new SqlConnectionStringBuilder
                {
                    MaxPoolSize = 2048,
                    DataSource = cmbMayChu.EditValue.ToString()
                };

                if (rdWindows.Checked)
                    sBuilder.IntegratedSecurity = true;
                else
                {
                    sBuilder.UserID = txtTaiKhoan.Text;
                    sBuilder.Password = txtMatKhau.Text;
                }
                return sBuilder;
            }

        }

        private void GetAllInstances()
        {
          //  SplashScreenManager.ShowForm(typeof(SplashScreenLoading));
            try
            {
                var instances = SqlServer.GetLocalInstances();
                cmbMayChu.Text = "";
                cmbMayChu.Properties.Items.Clear();
                cmbMayChu.Properties.Items.AddRange(instances);
                cmbMayChu.Text = instances.FirstOrDefault();
            }
            catch
            {
                cmbMayChu.Properties.Items.Clear();
                XtraMessageBox.Show("Xảy ra lỗi khi đọc thông tin về máy chủ, xin vui lòng kiểm tra lại cài đặt SQL Server!");
            }
          //  SplashScreenManager.CloseForm();
        }


        public void SetStyle()
        {
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            FormBorderEffect = FormBorderEffect.Shadow;
            FormBorderEffect = FormBorderEffect.Shadow;
        }

        private void frmCaiDatDuLieu_Load(object sender, EventArgs e)
        {

        }

        private void rdWindows_CheckedChanged(object sender, EventArgs e)
        {
            gcTaiKhoan.Enabled = rdServer.Checked;
        }

        private void rdServer_CheckedChanged(object sender, EventArgs e)
        {
            gcTaiKhoan.Enabled = rdServer.Checked;
        }


    }
}