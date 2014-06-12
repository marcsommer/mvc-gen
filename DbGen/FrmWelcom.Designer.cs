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
            DevExpress.XtraEditors.TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemFrame tileItemFrame1 = new DevExpress.XtraEditors.TileItemFrame();
            DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemFrame tileItemFrame2 = new DevExpress.XtraEditors.TileItemFrame();
            DevExpress.XtraEditors.TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemFrame tileItemFrame3 = new DevExpress.XtraEditors.TileItemFrame();
            DevExpress.XtraEditors.TileItemElement tileItemElement4 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement5 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemFrame tileItemFrame4 = new DevExpress.XtraEditors.TileItemFrame();
            DevExpress.XtraEditors.TileItemElement tileItemElement6 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemFrame tileItemFrame5 = new DevExpress.XtraEditors.TileItemFrame();
            DevExpress.XtraEditors.TileItemElement tileItemElement7 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemFrame tileItemFrame6 = new DevExpress.XtraEditors.TileItemFrame();
            DevExpress.XtraEditors.TileItemElement tileItemElement8 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement9 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement10 = new DevExpress.XtraEditors.TileItemElement();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWelcom));
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
            tileItemElement1.Text = "TỰ ĐỘNG SINH MÃ TỪ <br><size=+2>CƠ SỞ DỮ LIỆU CÓ SẴN</size>";
            this.btnDbFirst.Elements.Add(tileItemElement1);
            this.btnDbFirst.FrameAnimationInterval = 2000;
            tileItemFrame1.BackgroundImage = global::DbGen.Properties.Resources.database;
            tileItemElement2.Text = "TỰ ĐỘNG SINH MÃ TỪ <br><size=+2>CƠ SỞ DỮ LIỆU CÓ SẴN</size>";
            tileItemFrame1.Elements.Add(tileItemElement2);
            tileItemFrame2.BackgroundImage = global::DbGen.Properties.Resources.database_mysql;
            tileItemElement3.Text = "TỰ ĐỘNG SINH MÃ TỪ <br><size=+2>CƠ SỞ DỮ LIỆU CÓ SẴN</size>";
            tileItemFrame2.Elements.Add(tileItemElement3);
            tileItemFrame3.BackgroundImage = global::DbGen.Properties.Resources.database_sql;
            tileItemElement4.Text = "TỰ ĐỘNG SINH MÃ TỪ <br><size=+2>CƠ SỞ DỮ LIỆU CÓ SẴN</size>";
            tileItemFrame3.Elements.Add(tileItemElement4);
            this.btnDbFirst.Frames.Add(tileItemFrame1);
            this.btnDbFirst.Frames.Add(tileItemFrame2);
            this.btnDbFirst.Frames.Add(tileItemFrame3);
            this.btnDbFirst.Id = 5;
            this.btnDbFirst.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            this.btnDbFirst.Name = "btnDbFirst";
            this.btnDbFirst.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.btnDbFirst_ItemClick);
            // 
            // btnModelFirst
            // 
            this.btnModelFirst.BackgroundImage = global::DbGen.Properties.Resources.appbar_language_csharp;
            this.btnModelFirst.BackgroundImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement5.Text = "TỰ ĐỘNG SINH MÃ KHI <br><size=+2>CHƯA CÓ CƠ SỞ DỮ LIỆU</size>";
            this.btnModelFirst.Elements.Add(tileItemElement5);
            tileItemFrame4.BackgroundImage = global::DbGen.Properties.Resources.cell_align;
            tileItemElement6.Text = "TỰ ĐỘNG SINH MÃ KHI <br><size=+2>CHƯA CÓ CƠ SỞ DỮ LIỆU</size>";
            tileItemFrame4.Elements.Add(tileItemElement6);
            tileItemFrame5.BackgroundImage = global::DbGen.Properties.Resources.appbar_language_csharp;
            tileItemElement7.Text = "TỰ ĐỘNG SINH MÃ KHI <br><size=+2>CHƯA CÓ CƠ SỞ DỮ LIỆU</size>";
            tileItemFrame5.Elements.Add(tileItemElement7);
            tileItemFrame6.BackgroundImage = global::DbGen.Properties.Resources.framework_net;
            tileItemElement8.Text = "TỰ ĐỘNG SINH MÃ KHI <br><size=+2>CHƯA CÓ CƠ SỞ DỮ LIỆU</size>";
            tileItemFrame6.Elements.Add(tileItemElement8);
            this.btnModelFirst.Frames.Add(tileItemFrame4);
            this.btnModelFirst.Frames.Add(tileItemFrame5);
            this.btnModelFirst.Frames.Add(tileItemFrame6);
            this.btnModelFirst.Id = 10;
            this.btnModelFirst.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide;
            this.btnModelFirst.Name = "btnModelFirst";
            this.btnModelFirst.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.btnModelFirst_ItemClick);
            // 
            // btnAbout
            // 
            this.btnAbout.BackgroundImage = global::DbGen.Properties.Resources.group;
            this.btnAbout.BackgroundImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement9.Text = "Thông tin";
            this.btnAbout.Elements.Add(tileItemElement9);
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
            tileItemElement10.Text = "Thoát";
            this.btnExit.Elements.Add(tileItemElement10);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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