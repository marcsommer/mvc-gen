using DbGenLibrary.SqlSchema;
using DbGenLibrary.Text;

namespace DbGenLibrary.SchemaExtend
{
    public class MapColumn
    {
        public MapColumn()
        {
            Display = true;
        }

        public MapColumn(SchemaColumn col)
            : this()
        {
            Display = !col.IsIdentity && !col.Type.Equals("byte[]");

            ColumnName = col.ColumnName;
            IsNullable = col.IsNullable;
            IsIdentity = col.IsIdentity;
            Type = col.Type;
            PkIndex = col.PkIndex;
        }

        public string DisplayText { get; set; }
        public string ColumnName { get; set; }
        public bool IsNullable { get; set; }
        public bool IsIdentity { get; set; }
        public string Type { get; set; }
        public int PkIndex { get; set; }
        public bool Display { get; set; }

        public bool IsPrimaryKey
        {
            get { return PkIndex >= 0; }
            set
            {
                if (value)
                    PkIndex = 0;
                else
                    PkIndex = -1;
            }
        }

        public string PropertyText
        {
            get { return ColumnName.SimpleString(); }
        }

        public string PropertyLabel
        {
            get { return string.IsNullOrWhiteSpace(DisplayText) ? PropertyText : DisplayText; }
        }

        public bool NameChanged
        {
            get { return !PropertyText.Equals(DisplayText); }
        }
    }
}