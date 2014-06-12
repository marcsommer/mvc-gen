namespace DbGen.ModelForm
{
    partial class FrmObject
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmObject));
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.contextMenuGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnRemoveCol = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKeyEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTypeEdit = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colNull = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNullEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            this.contextMenuGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colKeyEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colTypeEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colNullEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl
            // 
            this.gridControl.ContextMenuStrip = this.contextMenuGrid;
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(0, 0);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.gridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1,
            this.colTypeEdit,
            this.colNullEdit,
            this.colKeyEdit});
            this.gridControl.Size = new System.Drawing.Size(299, 226);
            this.gridControl.TabIndex = 0;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // contextMenuGrid
            // 
            this.contextMenuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRemoveCol});
            this.contextMenuGrid.Name = "contextMenuGrid";
            this.contextMenuGrid.Size = new System.Drawing.Size(153, 26);
            // 
            // btnRemoveCol
            // 
            this.btnRemoveCol.Name = "btnRemoveCol";
            this.btnRemoveCol.Size = new System.Drawing.Size(152, 22);
            this.btnRemoveCol.Text = "Xóa thuộc tính";
            this.btnRemoveCol.Click += new System.EventHandler(this.btnRemoveCol_Click);
            // 
            // gridView
            // 
            this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKey,
            this.colName,
            this.colType,
            this.colNull});
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.NewItemRowText = "Thêm thuộc tính";
            this.gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView_InitNewRow);
            this.gridView.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView_RowUpdated);
            // 
            // colKey
            // 
            this.colKey.Caption = "Khóa";
            this.colKey.ColumnEdit = this.colKeyEdit;
            this.colKey.FieldName = "IsPrimaryKey";
            this.colKey.Name = "colKey";
            this.colKey.Visible = true;
            this.colKey.VisibleIndex = 0;
            this.colKey.Width = 36;
            // 
            // colKeyEdit
            // 
            this.colKeyEdit.AutoHeight = false;
            this.colKeyEdit.Caption = "Check";
            this.colKeyEdit.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.colKeyEdit.Name = "colKeyEdit";
            // 
            // colName
            // 
            this.colName.Caption = "Tên thuộc tính";
            this.colName.FieldName = "ColumnName";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 133;
            // 
            // colType
            // 
            this.colType.Caption = "Kiểu dữ liệu";
            this.colType.ColumnEdit = this.colTypeEdit;
            this.colType.FieldName = "Type";
            this.colType.Name = "colType";
            this.colType.Visible = true;
            this.colType.VisibleIndex = 2;
            this.colType.Width = 79;
            // 
            // colTypeEdit
            // 
            this.colTypeEdit.AutoHeight = false;
            this.colTypeEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colTypeEdit.Items.AddRange(new object[] {
            "string",
            "bool",
            "decimal",
            "int",
            "DateTime",
            "Double",
            "long",
            "byte[]"});
            this.colTypeEdit.Name = "colTypeEdit";
            // 
            // colNull
            // 
            this.colNull.Caption = "Null";
            this.colNull.ColumnEdit = this.colNullEdit;
            this.colNull.FieldName = "IsNullable";
            this.colNull.MinWidth = 10;
            this.colNull.Name = "colNull";
            this.colNull.Visible = true;
            this.colNull.VisibleIndex = 3;
            this.colNull.Width = 33;
            // 
            // colNullEdit
            // 
            this.colNullEdit.AutoHeight = false;
            this.colNullEdit.AutoWidth = true;
            this.colNullEdit.Caption = "Có thể null";
            this.colNullEdit.Name = "colNullEdit";
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // FrmObject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 226);
            this.Controls.Add(this.gridControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmObject";
            this.Text = "frmTable";
            this.Load += new System.EventHandler(this.FrmTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            this.contextMenuGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colKeyEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colTypeEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colNullEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraGrid.Columns.GridColumn colNull;
        private DevExpress.XtraGrid.Columns.GridColumn colKey;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox colTypeEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit colNullEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit colKeyEdit;
        private System.Windows.Forms.ContextMenuStrip contextMenuGrid;
        private System.Windows.Forms.ToolStripMenuItem btnRemoveCol;
    }
}