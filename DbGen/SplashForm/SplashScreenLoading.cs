using System;
using DevExpress.XtraSplashScreen;

namespace DbGen.SplashForm
{
    public partial class SplashScreenLoading : SplashScreen
    {
        public enum SplashScreenCommand
        {
        }

        public SplashScreenLoading()
        {
            InitializeComponent();
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        private void SplashScreenLoading_Load(object sender, EventArgs e)
        {
        }
    }
}