using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;

namespace DbGen
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SkinManager.EnableFormSkins();
            BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");

            //Application.Run(new frmCauHinhKetNoi());

            var fKetNoi = new FrmConfig();
            if (fKetNoi.ShowDialog() == DialogResult.OK)
            {
                var f = new FrmControl(fKetNoi.SqlConnectionStringBuilder);
                f.ShowDialog();
            }
        }
    }
}