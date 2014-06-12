using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DbGen
{
    public partial class FrmWelcom : XtraForm
    {
        public FrmWelcom()
        {
            InitializeComponent();
        }

        private void btnExit_ItemClick(object sender, TileItemEventArgs e)
        {
            Application.Exit();
        }

        private void btnAbout_ItemClick(object sender, TileItemEventArgs e)
        {
            Hide();
            var f = new FrmAbout();
            f.ShowDialog();
            Show();
        }

        private void btnDbFirst_ItemClick(object sender, TileItemEventArgs e)
        {
            Hide();
            var fKetNoi = new FrmConfig();
            if (fKetNoi.ShowDialog() == DialogResult.OK)
            {
                var f = new FrmControl(fKetNoi.SqlConnectionStringBuilder);
                f.ShowDialog();
                Application.Exit();
            }
            else
            {
                Show();
            }
        }

        private void btnModelFirst_ItemClick(object sender, TileItemEventArgs e)
        {
            Hide();
            var frmModel = new FrmControlModelFirst();
            frmModel.ShowDialog();
            Application.Exit();
        }
    }
}