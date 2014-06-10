using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DbGenLibrary.SqlSchema;
using DbGenLibrary.Text;

namespace DbGenLibrary.SchemaExtend
{
    public class MapColumn
    {
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
        }

        public MapColumn()
        {
            Display = true;
        }
        public MapColumn(SchemaColumn col)
            : this()
        {
            Display = !col.IsIdentity;

            ColumnName = col.ColumnName;
            IsNullable = col.IsNullable;
            IsIdentity = col.IsIdentity;
            Type = col.Type;
            PkIndex = col.PkIndex;
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
