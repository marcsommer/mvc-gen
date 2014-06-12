using System;
using System.Linq;
using DbGenLibrary.IO;
using DbGenLibrary.SchemaExtend;
using DbGenLibrary.Text;

namespace DbGenLibrary.SolutionGen.SQL
{
    internal class SqlScript
    {
        public static TextFile GenSqlScript(GenInfo info)
        {
            string sql = "";
            sql += string.Format(@"USE master
go
IF  EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'{0}')
DROP DATABASE [{0}]
go
CREATE DATABASE [{0}];
go
USE [{0}];
go" + "\n", info.NameSpace);
            sql += string.Join("\n\n", info.Tables.Select(GetTableStament));
            return new TextFile(sql, string.Format("{0}.sql", info.NameSpace));
        }

        private static string GetTableStament(MapTable table)
        {
            string result = "";
            result += string.Format("CREATE TABLE [{0}](\n", table.TableName);
            result += string.Join(",\n", table.Columns.Select(c => GetColumnStament(c).WithIndent(1)));
            result += "\n);\n";
            return result;
        }

        private static string GetColumnStament(MapColumn column)
        {
            string result = "";
            result += string.Format("[{0}]", column.ColumnName);
            result += string.Format(" {0}", GetSqlType(column.Type));
            if (!column.IsNullable)
                result += " NOT NULL";
            if (column.IsPrimaryKey)
                result += " PRIMARY KEY";
            if (column.IsIdentity || column.IsPrimaryKey && column.Type.Equals("int", StringComparison.OrdinalIgnoreCase))
                result += " IDENTITY";

            return result;
        }

        private static string GetSqlType(string type)
        {
            switch (type)
            {
                case "string":
                    return "NVARCHAR(MAX)";
                case "bool":
                    return "BIT";
                case "decimal":
                    return "DECIMAL";
                case "int":
                    return "INT";
                case "DateTime":
                    return "DATETIME";
                case "Double":
                    return "FLOAT";
                case "long":
                    return "BIGINT";
                case "byte[]":
                    return "VARBINARY(MAX)";
                default:
                    return "";
            }
        }
    }
}