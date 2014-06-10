﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbGenLibrary.SqlSchema;
using DbGenLibrary.Text;

namespace DbGenLibrary.SchemaExtend
{
    public class MapTable
    {
        public string DisplayText { get; set; }
        public List<MapColumn> Columns { get; set; }
        public List<MapForeignKey> ForeignKeys { get; set; }
        public string TableName { get; set; }
        public bool Display { get; set; }
        public MapTable()
        {
            Display = true;
        }

        public MapTable(SchemaTable table)
            : this()
        {
            TableName = table.TableName;
            Columns = table.Columns.Values.Select(c => new MapColumn(c)).ToList();
            ForeignKeys = table.ForeignKeys.Values.Select(fk => new MapForeignKey(fk)).ToList();
        }

        public string ClassText
        {
            get { return TableName.SimpleString(); }
        }
        public string ClassLabel
        {
            get { return string.IsNullOrWhiteSpace(DisplayText) ? TableName : DisplayText; }
        }
        public bool NameChanged
        {
            get { return !ClassText.Equals(TableName); }
        }

        public MapColumn PrimaryKey
        {
            get { return Columns.FirstOrDefault(c => c.IsPrimaryKey); }
        }
    }
}
