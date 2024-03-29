﻿using System;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;

namespace DbGen
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SkinManager.EnableFormSkins();
            BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");


            var fwelcome = new FrmWelcom();
            fwelcome.ShowDialog();
        }
    }
}