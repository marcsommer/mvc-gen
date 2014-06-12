namespace DbGen
{
    partial class FrmWelcom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraEditors.TileItemElement tileItemElement11 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemFrame tileItemFrame7 = new DevExpress.XtraEditors.TileItemFrame();
            DevExpress.XtraEditors.TileItemElement tileItemElement12 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemFrame tileItemFrame8 = new DevExpress.XtraEditors.TileItemFrame();
            DevExpress.XtraEditors.TileItemElement tileItemElement13 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemFrame tileItemFrame9 = new DevExpress.XtraEditors.TileItemFrame();
            DevExpress.XtraEditors.TileItemElement tileItemElement14 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement15 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemFrame tileItemFrame10 = new DevExpress.XtraEditors.TileItemFrame();
            DevExpress.XtraEditors.TileItemElement tileItemElement16 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemFrame tileItemFrame11 = new DevExpress.XtraEditors.TileItemFrame();
            DevExpress.XtraEditors.TileItemElement tileItemElement17 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemFrame tileItemFrame12 = new DevExpress.XtraEditors.TileItemFrame();
            DevExpress.XtraEditors.TileItemElement tileItemElement18 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement19 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement20 = new DevExpress.XtraEditors.TileItemElement();
            this.tileControl = new DevExpress.XtraEditors.TileControl();
            this.tileGroup2 = new DevExpress.XtraEditors.TileGroup();
            this.btnDbFirst = new DevExpress.XtraEditors.TileItem();
            this.btnModelFirst = new DevExpress.XtraEditors.TileItem();
            this.btnAbout = new DevExpress.XtraEditors.TileItem();
            this.btnExit = new DevExpress.XtraEditors.TileItem();
            this.SuspendLayout();
            // 
            // tileControl
            // 
            this.tileControl.BackColor = System.Drawing.Color.Transparent;
            this.tileControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tileControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tileControl.Groups.Add(this.tileGroup2);
            this.tileControl.Location = new System.Drawing.Point(0, 0);
            this.tileControl.MaxId = 11;
            this.tileControl.Name = "tileControl";
            this.tileControl.Size = new System.Drawing.Size(547, 303);
            this.tileControl.TabIndex = 0;
            // 
            // tileGroup2
            // 
            this.tileGroup2.Items.Add(this.btnDbFirst);
            this.tileGroup2.Items.Add(this.btnModelFirst);
            this.tileGroup2.Items.Add(this.btnAbout);
            this.tileGroup2.Items.Add(this.btnExit);
            this.tileGroup2.Name = "tileGroup2";
            this.tileGroup2.Text = null;
            // 
            // btnDbFirst
            // 
            this.btnDbFirst.BackgroundImage = global::DbGen.Properties.Resources.database_sql;
            this.btnDbFirst.BackgroundImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement11.Text = "TỰ ĐỘNG SINH MÃ TỪ <br><size=+2>CƠ SỞ DỮ LIỆU CÓ SẴN</size>";
            this.btnDbFirst.Elements.Add(tileItemElement11);
            this.btnDbFirst.FrameAnimationInterval = 2000;
            tileItemFrame7.BackgroundImage = global::DbGen.Properties.Resources.database;
            tileItemElement12.Text = "TỰ ĐỘNG SINH MÃ TỪ <br><size=+2>CƠ SỞ DỮ LIỆU CÓ SẴN</size>";
            tileItemFrame7.Elements.Add(tileItemElement12);
            tileItemFrame8.BackgroundImage = global::DbGen.Properties.Resources.database_mysql;
            tileItemElement13.Text = "TỰ ĐỘNG SINH MÃ TỪ <br><size=+2>CƠ SỞ DỮ LIỆU CÓ SẴN</size>";
            tileItemFrame8.Elements.Add(tileItemElement13);
            tileItemFrame9.BackgroundImage = global::DbGen.Properties.Resources.database_sql;
            tileItemElement14.Text = "TỰ ĐỘNG SINH MÃ TỪ <br><size=+2>CƠ SỞ DỮ LIỆU CÓ SẴN</size>";
            tileItemFrame9.Elements.Add(tileItemElement14);
            this.btnDbFirst.Frames.Add(tileItemFrame7);
            this.btnDbFirst.Frames.Add(tileItemFrame8);
            this.btnDbFirst.Frames.Add(tileItemFrame9);
            this.btnDbFirst.Id = 5;
            this.btnDbFirst.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            this.btnDbFirst.Name = "btnDbFirst";
            this.btnDbFirst.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.btnDbFirst_ItemClick);
            // 
            // btnModelFirst
            // 
            this.btnModelFirst.BackgroundImage = global::DbGen.Properties.Resources.appbar_language_csharp;
            this.btnModelFirst.BackgroundImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement15.Text = "TỰ ĐỘNG SINH MÃ KHI <br><size=+2>CHƯA CÓ CƠ SỞ DỮ LIỆU</size>";
            this.btnModelFirst.Elements.Add(tileItemElement15);
            tileItemFrame10.BackgroundImage = global::DbGen.Properties.Resources.cell_align;
            tileItemElement16.Text = "TỰ ĐỘNG SINH MÃ KHI <br><size=+2>CHƯA CÓ CƠ SỞ DỮ LIỆU</size>";
            tileItemFrame10.Elements.Add(tileItemElement16);
            tileItemFrame11.BackgroundImage = global::DbGen.Properties.Resources.appbar_language_csharp;
            tileItemElement17.Text = "TỰ ĐỘNG SINH MÃ KHI <br><size=+2>CHƯA CÓ CƠ SỞ DỮ LIỆU</size>";
            tileItemFrame11.Elements.Add(tileItemElement17);
            tileItemFrame12.BackgroundImage = global::DbGen.Properties.Resources.framework_net;
            tileItemElement18.Text = "TỰ ĐỘNG SINH MÃ KHI <br><size=+2>CHƯA CÓ CƠ SỞ DỮ LIỆU</size>";
            tileItemFrame12.Elements.Add(tileItemElement18);
            this.btnModelFirst.Frames.Add(tileItemFrame10);
            this.btnModelFirst.Frames.Add(tileItemFrame11);
            this.btnModelFirst.Frames.Add(tileItemFrame12);
            this.btnModelFirst.Id = 10;
            this.btnModelFirst.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            this.btnModelFirst.Name = "btnModelFirst";
            this.btnModelFirst.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.btnModelFirst_ItemClick);
            // 
            // btnAbout
            // 
            this.btnAbout.BackgroundImage = global::DbGen.Properties.Resources.group;
            this.btnAbout.BackgroundImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement19.Text = "Thông tin";
            this.btnAbout.Elements.Add(tileItemElement19);
            this.btnAbout.Id = 9;
            this.btnAbout.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.btnAbout_ItemClick);
            // 
            // btnExit
            // 
            this.btnExit.AppearanceItem.Hovered.Options.UseTextOptions = true;
            this.btnExit.AppearanceItem.Hovered.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.btnExit.AppearanceItem.Hovered.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.btnExit.BackgroundImage = global::DbGen.Properties.Resources.appbar_door_leave;
            this.btnExit.BackgroundImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement20.Text = "Thoát";
            this.btnExit.Elements.Add(tileItemElement20);
            this.btnExit.Id = 3;
            this.btnExit.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.btnExit.Name = "btnExit";
            this.btnExit.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.btnExit_ItemClick);
            // 
            // FrmWelcom
            // 
            this.ActiveGlowColor = System.Drawing.Color.Empty;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 303);
            this.Controls.Add(this.tileControl);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.InactiveGlowColor = System.Drawing.Color.Empty;
            this.Name = "FrmWelcom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmWelcom";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TileControl tileControl;
        private DevExpress.XtraEditors.TileGroup tileGroup2;
        private DevExpress.XtraEditors.TileItem btnExit;
        private DevExpress.XtraEditors.TileItem btnDbFirst;
        private DevExpress.XtraEditors.TileItem btnModelFirst;
        private DevExpress.XtraEditors.TileItem btnAbout;
    }
}