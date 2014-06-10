namespace DbGen
{
    partial class FrmConfig
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
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::DbGen.SplashForm.SplashScreenLoading), true, true);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfig));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.gcTaiKhoan = new DevExpress.XtraEditors.GroupControl();
            this.txtMatKhau = new DevExpress.XtraEditors.TextEdit();
            this.txtTaiKhoan = new DevExpress.XtraEditors.TextEdit();
            this.rdWindows = new System.Windows.Forms.RadioButton();
            this.rdServer = new System.Windows.Forms.RadioButton();
            this.btnKiemTra = new DevExpress.XtraEditors.SimpleButton();
            this.cmbMayChu = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.gcTaiKhoan)).BeginInit();
            this.gcTaiKhoan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaiKhoan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMayChu.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(12, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 16);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "Máy chủ";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(5, 8);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(65, 16);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Người dùng";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(5, 35);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(52, 16);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Mật khẩu";
            // 
            // gcTaiKhoan
            // 
            this.gcTaiKhoan.Controls.Add(this.txtMatKhau);
            this.gcTaiKhoan.Controls.Add(this.txtTaiKhoan);
            this.gcTaiKhoan.Controls.Add(this.labelControl3);
            this.gcTaiKhoan.Controls.Add(this.labelControl4);
            this.gcTaiKhoan.Enabled = false;
            this.gcTaiKhoan.Location = new System.Drawing.Point(23, 41);
            this.gcTaiKhoan.Name = "gcTaiKhoan";
            this.gcTaiKhoan.ShowCaption = false;
            this.gcTaiKhoan.Size = new System.Drawing.Size(256, 60);
            this.gcTaiKhoan.TabIndex = 3;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(85, 32);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Properties.UseSystemPasswordChar = true;
            this.txtMatKhau.Size = new System.Drawing.Size(166, 20);
            this.txtMatKhau.TabIndex = 1;
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Location = new System.Drawing.Point(85, 5);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(166, 20);
            this.txtTaiKhoan.TabIndex = 0;
            // 
            // rdWindows
            // 
            this.rdWindows.AutoSize = true;
            this.rdWindows.Checked = true;
            this.rdWindows.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdWindows.Location = new System.Drawing.Point(15, 18);
            this.rdWindows.Name = "rdWindows";
            this.rdWindows.Size = new System.Drawing.Size(136, 20);
            this.rdWindows.TabIndex = 1;
            this.rdWindows.TabStop = true;
            this.rdWindows.Text = "Tài khoản windows";
            this.rdWindows.UseVisualStyleBackColor = true;
            this.rdWindows.CheckedChanged += new System.EventHandler(this.rdWindows_CheckedChanged);
            // 
            // rdServer
            // 
            this.rdServer.AutoSize = true;
            this.rdServer.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdServer.Location = new System.Drawing.Point(158, 18);
            this.rdServer.Name = "rdServer";
            this.rdServer.Size = new System.Drawing.Size(93, 20);
            this.rdServer.TabIndex = 2;
            this.rdServer.TabStop = true;
            this.rdServer.Text = "SQL server ";
            this.rdServer.UseVisualStyleBackColor = true;
            this.rdServer.CheckedChanged += new System.EventHandler(this.rdServer_CheckedChanged);
            // 
            // btnKiemTra
            // 
            this.btnKiemTra.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKiemTra.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnKiemTra.Appearance.Options.UseFont = true;
            this.btnKiemTra.Appearance.Options.UseForeColor = true;
            this.btnKiemTra.Location = new System.Drawing.Point(12, 166);
            this.btnKiemTra.Name = "btnKiemTra";
            this.btnKiemTra.Size = new System.Drawing.Size(137, 31);
            this.btnKiemTra.TabIndex = 5;
            this.btnKiemTra.Text = "Kiểm tra kết nối";
            this.btnKiemTra.Click += new System.EventHandler(this.btnKiemTra_Click);
            // 
            // cmbMayChu
            // 
            this.cmbMayChu.Location = new System.Drawing.Point(78, 11);
            this.cmbMayChu.Name = "cmbMayChu";
            this.cmbMayChu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbMayChu.Size = new System.Drawing.Size(229, 20);
            this.cmbMayChu.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Appearance.ForeColor = System.Drawing.Color.Green;
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.Appearance.Options.UseForeColor = true;
            this.btnOK.Location = new System.Drawing.Point(175, 166);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(137, 31);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "Kết nối";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdWindows);
            this.groupBox1.Controls.Add(this.rdServer);
            this.groupBox1.Controls.Add(this.gcTaiKhoan);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(14, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 118);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Phương thức xác thực";
            // 
            // FrmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 205);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnKiemTra);
            this.Controls.Add(this.cmbMayChu);
            this.Controls.Add(this.btnOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cài đặt dữ liệu";
            this.Load += new System.EventHandler(this.frmCaiDatDuLieu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcTaiKhoan)).EndInit();
            this.gcTaiKhoan.ResumeLayout(false);
            this.gcTaiKhoan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaiKhoan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMayChu.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.GroupControl gcTaiKhoan;
        private DevExpress.XtraEditors.TextEdit txtMatKhau;
        private DevExpress.XtraEditors.TextEdit txtTaiKhoan;
        private System.Windows.Forms.RadioButton rdWindows;
        private System.Windows.Forms.RadioButton rdServer;
        private DevExpress.XtraEditors.SimpleButton btnKiemTra;
        private DevExpress.XtraEditors.ComboBoxEdit cmbMayChu;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}