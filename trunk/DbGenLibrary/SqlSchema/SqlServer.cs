using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Smo.Wmi;

namespace DbGenLibrary.SqlSchema
{
    public class SqlServer : SqlInformation
    {
        public SqlServer(SqlConnectionStringBuilder cnnBuilder)
        {
            Builder = cnnBuilder;
        }

        public SqlConnectionStringBuilder Builder { get; set; }

        /// <summary>
        ///     lấy tất cả các thể hiện SQL trong máy
        /// </summary>
        /// <returns>danh sách các thể hiện</returns>
        public static List<string> GetLocalInstances()
        {
            List<string> ls = new ManagedComputer().ServerInstances
                .Cast<ServerInstance>()
                .Select(instance => String.IsNullOrEmpty(instance.Name)
                    ? instance.Parent.Name
                    : Path.Combine(instance.Parent.Name, instance.Name))
                .ToList();
            ls.Add("(local)");
            return ls;
        }

        /// <summary>
        ///     kiểm tra kết nối
        /// </summary>
        /// <param name="cnn">chuỗi kết nối</param>
        /// <returns>trả về kết quả kiểm tra</returns>
        public static bool TestConnection(string cnn)
        {
            try
            {
                var con = new SqlConnection(cnn);
                con.Open();
                con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<string> Databases()
        {
            using (var connection = new SqlConnection(Builder.ConnectionString))
            {
                var tableNames = new List<string>();
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM  sysdatabases";
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    tableNames.Add(rd["Name"].ToString());
                }
                return tableNames;
            }
        }

        public void ExecuteSql(string sql)
        {
            using (var connection = new SqlConnection(Builder.ConnectionString))
            {
                /*
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                */

                var server = new Server(new ServerConnection(connection));

                server.ConnectionContext.ExecuteNonQuery(sql);
            }
        }

        protected override void GetSchema(out List<SchemaTable> tables, out List<SchemaColumn> columns)
        {
            tables = GetTables();
            columns = GetColumns();
            LoadPrimaryKeys(columns);
            LoadForeignKes(tables, columns);
        }

        private List<SchemaTable> GetTables()
        {
            const string s = @"
                SELECT  TABLE_CATALOG + '.' + TABLE_SCHEMA + '.' + TABLE_NAME AS TABLE_FULLNAME ,
                    TABLE_SCHEMA ,
                    TABLE_NAME ,
                    TABLE_TYPE ,
                    ISNULL(CONVERT(VARCHAR(8000), x.Value), '') AS TABLE_DESC
                FROM    INFORMATION_SCHEMA.TABLES s
                    LEFT JOIN sys.tables t ON OBJECT_ID(TABLE_CATALOG + '.' + TABLE_SCHEMA
                                                        + '.' + TABLE_NAME) = t.object_id
                    LEFT JOIN sys.extended_properties x ON OBJECT_ID(TABLE_CATALOG + '.'
                                                                     + TABLE_SCHEMA + '.'
                                                                     + TABLE_NAME) = x.major_id
                                                           AND x.minor_id = 0
                                                           AND x.name = 'MS_Description'
                WHERE   ( t.object_id IS NULL
                      OR t.is_ms_shipped <> 1
                      AND ( SELECT  major_id
                            FROM    sys.extended_properties
                            WHERE   major_id = t.object_id
                                    AND minor_id = 0
                                    AND class = 1
                                    AND name = N'microsoft_database_tools_support'
                          ) IS NULL
                    )
                    AND TABLE_TYPE = 'BASE TABLE'";

            var tables = new List<SchemaTable>();
            using (var connection = new SqlConnection(Builder.ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = s;
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    var t = new SchemaTable
                    {
                        Owner = rd[1].ToString(),
                        TableName = rd[2].ToString(),
                        Description = Convert.ToString(rd[4]),
                    };
                    tables.Add(t);
                }
                return tables;
            }
        }

        private List<SchemaColumn> GetColumns()
        {
            const string s = @"
                    SELECT  TABLE_NAME AS tableName ,
                            ( CASE WHEN IS_NULLABLE = 'YES' THEN 1
                                   ELSE 0
                              END ) AS isNullable ,
                            ORDINAL_POSITION AS colid ,
                            COLUMN_NAME AS name ,
                            c.DATA_TYPE AS dataType ,
                            CHARACTER_MAXIMUM_LENGTH AS length ,
                            ISNULL(NUMERIC_PRECISION, DATETIME_PRECISION) AS prec ,
                            NUMERIC_SCALE AS scale ,
                            COLUMNPROPERTY(OBJECT_ID('[' + TABLE_SCHEMA + '].[' + TABLE_NAME + ']'),
                                           COLUMN_NAME, 'IsIdentity') AS isIdentity ,
                            ISNULL(CONVERT(VARCHAR(8000), x.Value), '') AS COLUMN_DESC
                    FROM    INFORMATION_SCHEMA.COLUMNS c
                            LEFT JOIN sys.extended_properties x ON OBJECT_ID(TABLE_CATALOG + '.'
                                                                             + TABLE_SCHEMA + '.'
                                                                             + TABLE_NAME) = x.major_id
                                                                   AND ORDINAL_POSITION = x.minor_id
                                                                   AND x.name = 'MS_Description'             
                    ";

            var columns = new List<SchemaColumn>();
            using (var connection = new SqlConnection(Builder.ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = s;
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    var column = new SchemaColumn
                    {
                        Id = Convert.ToInt16(rd["colid"]),
                        ColumnName = Convert.ToString(rd["name"]),
                        MemberName = Convert.ToString(rd["name"]),
                        ColumnType = Convert.ToString(rd["dataType"]),
                        IsNullable = Convert.ToBoolean(rd["isNullable"]),
                        IsIdentity = Convert.ToBoolean(rd["isIdentity"]),
                        Length = rd.IsDBNull(rd.GetOrdinal("length")) ? 0 : Convert.ToInt64(rd["length"]),
                        Precision = rd.IsDBNull(rd.GetOrdinal("prec")) ? 0 : Convert.ToInt32(rd["prec"]),
                        Scale = rd.IsDBNull(rd.GetOrdinal("scale")) ? 0 : Convert.ToInt32(rd["scale"]),
                        Description = Convert.ToString(rd["COLUMN_DESC"]),
                        TableName = Convert.ToString(rd["tableName"])
                    };
                    TypeConverter.CompleteColunmType(column);
                    columns.Add(column);
                }


                return columns;
            }
        }


        private void LoadPrimaryKeys(List<SchemaColumn> columns)
        {
            string s = @"
			SELECT
				k.TABLE_NAME as tableName,
				k.CONSTRAINT_NAME                                             as name,
				k.COLUMN_NAME                                                 as colname,
				k.ORDINAL_POSITION                                            as colid
			FROM
				INFORMATION_SCHEMA.KEY_COLUMN_USAGE k
			  JOIN 
				INFORMATION_SCHEMA.TABLE_CONSTRAINTS c 
			  ON 
				k.CONSTRAINT_CATALOG = c.CONSTRAINT_CATALOG AND 
				k.CONSTRAINT_SCHEMA = c.CONSTRAINT_SCHEMA AND 
				k.CONSTRAINT_NAME = c.CONSTRAINT_NAME
			WHERE
				c.CONSTRAINT_TYPE='PRIMARY KEY' 
            ";

            using (var connection = new SqlConnection(Builder.ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = s;
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string tableName = Convert.ToString(rd["tableName"]);
                    int colid = Convert.ToInt32(rd["colid"]);
                    string colname = Convert.ToString(rd["colname"]);
                    ////
                    columns.First(_ => _.TableName == tableName && _.ColumnName == colname).PkIndex = colid;
                }
            }
        }

        private void LoadForeignKes(List<SchemaTable> tables, List<SchemaColumn> columns)
        {
            const string s = @"
            SELECT
				rc.CONSTRAINT_NAME  as Name, 
				fk.TABLE_NAME as ThisTable,
				fk.COLUMN_NAME      as ThisColumn,
				pk.TABLE_NAME as OtherTable,
				pk.COLUMN_NAME      as OtherColumn,
				cu.ORDINAL_POSITION as Ordinal
			FROM
				INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS rc
			  JOIN 
				INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE fk
					ON
						rc.CONSTRAINT_CATALOG        = fk.CONSTRAINT_CATALOG AND
				rc.CONSTRAINT_SCHEMA		 = fk.CONSTRAINT_SCHEMA AND
						rc.CONSTRAINT_NAME           = fk.CONSTRAINT_NAME
			  JOIN 
				INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE pk
					ON
						rc.UNIQUE_CONSTRAINT_CATALOG = pk.CONSTRAINT_CATALOG AND
				rc.UNIQUE_CONSTRAINT_SCHEMA	 = pk.CONSTRAINT_SCHEMA AND
						rc.UNIQUE_CONSTRAINT_NAME    = pk.CONSTRAINT_NAME
			  JOIN 
				INFORMATION_SCHEMA.KEY_COLUMN_USAGE cu
					ON
				rc.CONSTRAINT_CATALOG = cu.CONSTRAINT_CATALOG AND
				rc.CONSTRAINT_SCHEMA = cu.CONSTRAINT_SCHEMA AND
						rc.CONSTRAINT_NAME = cu.CONSTRAINT_NAME
			ORDER BY
				ThisTable,
				Ordinal
     ";

            using (var connection = new SqlConnection(Builder.ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = s;
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    string name = Convert.ToString(rd["Name"]);
                    string thisTableId = Convert.ToString(rd["ThisTable"]);
                    string otherTableId = Convert.ToString(rd["OtherTable"]);
                    string thisColumnName = Convert.ToString(rd["ThisColumn"]);
                    string otherColumnName = Convert.ToString(rd["OtherColumn"]);

                    SchemaTable thisSchemaTable = tables.Single(t => t.TableName == thisTableId);
                    SchemaTable otherSchemaTable = tables.Single(t => t.TableName == otherTableId);
                    SchemaColumn thisSchemaColumn = columns.Single(c => c.TableName == thisTableId && c.ColumnName == thisColumnName);
                    SchemaColumn otherSchemaColumn = columns.Single(c => c.TableName == otherTableId && c.ColumnName == otherColumnName);

                    if (thisSchemaTable.ForeignKeys.ContainsKey(name) == false)
                        thisSchemaTable.ForeignKeys.Add(name, new SchemaForeignKey
                        {
                            KeyName = name,
                            MemberName = name,
                            OtherTable = otherSchemaTable
                        });
                    SchemaForeignKey key = thisSchemaTable.ForeignKeys[name];
                    key.ThisColumns.Add(thisSchemaColumn);
                    key.OtherColumns.Add(otherSchemaColumn);
                }
            }
        }
    }
}