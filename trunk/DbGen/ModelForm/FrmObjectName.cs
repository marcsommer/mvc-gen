using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DbGen.ModelForm
{
    public partial class FrmObjectName : DevExpress.XtraEditors.XtraForm
    {
        public FrmObjectName()
        {
            InitializeComponent();

        }
        public FrmObjectName(string text)
            : this()
        {
            ObjName = text;

        }


        public string ObjName
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }

        }
        private void ObjectName_Load(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ObjName))
            {
                XtraMessageBox.Show("Xin nhập tên thực thể");
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}