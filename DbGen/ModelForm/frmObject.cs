using System;
using System.ComponentModel;
using System.Linq;
using DbGen.Properties;
using DbGenLibrary.SchemaExtend;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace DbGen.ModelForm
{
    public partial class FrmObject : XtraForm
    {

        public FrmObject()
        {
            InitializeComponent();

            colKeyEdit.PictureChecked = Resources.key;

            Columns = new BindingList<MapColumn>
            {
                new MapColumn() {ColumnName = "ID", IsNullable = false, IsPrimaryKey = true, Type = "int"}, 
                new MapColumn() {ColumnName = "Name", IsNullable = false, IsPrimaryKey = false, Type = "string"}
            };
        }

        public BindingList<MapColumn> Columns { get; set; }
        private void gridView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
          //  gridView.SetRowCellValue(e.RowHandle, "ColumnName", string.Format("Property{0}", Columns.Count + 1));
            gridView.SetRowCellValue(e.RowHandle, "IsNullable", true);
            gridView.SetRowCellValue(e.RowHandle, "Type", "string");
            gridView.SetRowCellValue(e.RowHandle, "IsPrimaryKey", false);
        }

        private void FrmTable_Load(object sender, EventArgs e)
        {
            gridControl.DataSource = Columns;
        }


        private void gridView_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            if ((e.Row as MapColumn) != null && (e.Row as MapColumn).IsPrimaryKey)
            {
                for (int index = 0; index < Columns.Count; index++)
                {
                    if (index != e.RowHandle)
                    {
                        var column = Columns[index];
                        column.IsPrimaryKey = false;
                    }
                }
                gridView.RefreshData();
            }
        }

        private void btnRemoveCol_Click(object sender, EventArgs e)
        {
            if (gridView.SelectedRowsCount > 0)
            {
                try
                {
                    var rows = gridView.GetSelectedRows().Select(r => Columns[r]);
                    foreach (var row in rows)
                    {
                        Columns.Remove(row);
                    }
                    gridView.RefreshData();
                }
                catch (Exception)
                {

                }

            }
        }

    }
}