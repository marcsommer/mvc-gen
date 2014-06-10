using System.Data;

namespace DbGenLibrary.SqlSchema
{
    internal class TypeConverter
    {
        public static void CompleteColunmType(SchemaColumn col)
        {
            switch (col.ColumnType)
            {
                case "image":
                    col.Type = "byte[]";
                    col.DbType = DbType.Binary;
                    col.SqlDbType = SqlDbType.Image;
                    break;
                case "text":
                    col.Type = "string";
                    col.DbType = DbType.String;
                    col.SqlDbType = SqlDbType.Text;
                    break;
                case "binary":
                    col.Type = "byte[]";
                    col.DbType = DbType.Binary;
                    col.SqlDbType = SqlDbType.Binary;
                    break;
                case "tinyint":
                    col.Type = "byte";
                    col.DbType = DbType.Byte;
                    col.SqlDbType = SqlDbType.TinyInt;
                    break;
                case "date":
                    col.Type = "DateTime";
                    col.DbType = DbType.Date;
                    col.SqlDbType = SqlDbType.Date;
                    break;
                case "time":
                    col.Type = "DateTime";
                    col.DbType = DbType.Time;
                    col.SqlDbType = SqlDbType.Time;
                    break;
                case "bit":
                    col.Type = "bool";
                    col.DbType = DbType.Boolean;
                    col.SqlDbType = SqlDbType.Bit;
                    break;
                case "smallint":
                    col.Type = "short";
                    col.DbType = DbType.Int16;
                    col.SqlDbType = SqlDbType.SmallInt;
                    break;
                case "decimal":
                    col.Type = "decimal";
                    col.DbType = DbType.Decimal;
                    col.SqlDbType = SqlDbType.Decimal;
                    break;
                case "int":
                    col.Type = "int";
                    col.DbType = DbType.Int32;
                    col.SqlDbType = SqlDbType.Int;
                    break;
                case "smalldatetime":
                    col.Type = "DateTime";
                    col.DbType = DbType.DateTime;
                    col.SqlDbType = SqlDbType.SmallDateTime;
                    break;
                case "real":
                    col.Type = "float";
                    col.DbType = DbType.Single;
                    col.SqlDbType = SqlDbType.Real;
                    break;
                case "money":
                    col.Type = "decimal";
                    col.DbType = DbType.Currency;
                    col.SqlDbType = SqlDbType.Money;
                    break;
                case "datetime":
                    col.Type = "DateTime";
                    col.DbType = DbType.DateTime;
                    col.SqlDbType = SqlDbType.DateTime;
                    break;
                case "float":
                    col.Type = "double";
                    col.DbType = DbType.Double;
                    col.SqlDbType = SqlDbType.Float;
                    break;
                case "numeric":
                    col.Type = "decimal";
                    col.DbType = DbType.Decimal;
                    col.SqlDbType = SqlDbType.Decimal;
                    break;
                case "smallmoney":
                    col.Type = "decimal";
                    col.DbType = DbType.Currency;
                    col.SqlDbType = SqlDbType.SmallMoney;
                    break;
                case "datetime2":
                    col.Type = "DateTime";
                    col.DbType = DbType.DateTime2;
                    col.SqlDbType = SqlDbType.DateTime2;
                    break;
                case "bigint":
                    col.Type = "long";
                    col.DbType = DbType.Int64;
                    col.SqlDbType = SqlDbType.BigInt;
                    break;
                case "varbinary":
                    col.Type = "byte[]";
                    col.DbType = DbType.Binary;
                    col.SqlDbType = SqlDbType.VarBinary;
                    break;
                case "timestamp":
                    col.Type = "byte[]";
                    col.DbType = DbType.Binary;
                    col.SqlDbType = SqlDbType.Timestamp;
                    break;
                case "sysname":
                    col.Type = "string";
                    col.DbType = DbType.String;
                    col.SqlDbType = SqlDbType.NVarChar;
                    break;
                case "nvarchar":
                    col.Type = "string";
                    col.DbType = DbType.String;
                    col.SqlDbType = SqlDbType.NVarChar;
                    break;
                case "varchar":
                    col.Type = "string";
                    col.DbType = DbType.AnsiString;
                    col.SqlDbType = SqlDbType.VarChar;
                    break;
                case "ntext":
                    col.Type = "string";
                    col.DbType = DbType.String;
                    col.SqlDbType = SqlDbType.NText;
                    break;
                case "uniqueidentifier":
                    col.Type = "Guid";
                    col.DbType = DbType.Binary;
                    col.SqlDbType = SqlDbType.UniqueIdentifier;
                    break;
                case "datetimeoffset":
                    col.Type = "DateTimeOffset";
                    col.DbType = DbType.DateTimeOffset;
                    col.SqlDbType = SqlDbType.DateTimeOffset;
                    break;
                case "sql_variant":
                    col.Type = "object";
                    col.DbType = DbType.Binary;
                    col.SqlDbType = SqlDbType.Variant;
                    break;
                case "xml":
                    col.Type = "string";
                    col.DbType = DbType.Xml;
                    col.SqlDbType = SqlDbType.Xml;
                    break;

                case "char":
                    col.Type = col.Length == 1 ? "char" : "string";
                    col.DbType = DbType.AnsiStringFixedLength;
                    col.SqlDbType = SqlDbType.Char;
                    break;

                case "nchar":
                    col.Type = col.Length == 1 ? "char" : "string";
                    col.DbType = DbType.StringFixedLength;
                    col.SqlDbType = SqlDbType.NChar;
                    break;
                default:
                    col.Type = "byte[]";
                    col.DbType = DbType.Binary;
                    col.SqlDbType = SqlDbType.Binary;
                    break;
            }

            switch (col.Type)
            {
                case "string":
                case "object":
                case "byte[]":
                    col.IsClass = true;
                    break;
            }

            if (col.IsNullable && !col.IsClass)
                col.Type += "?";
        }
    }
}