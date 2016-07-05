using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toyshop
{
    static class Utils
    {
        public static OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\toyshop.accdb");

        public static string[] DataTypes = new string[] { "String", "Int32", "Boolean", "Decimal", "DateTime", "Byte[]" };
        public static OleDbType[] OleDbDataTypes = new OleDbType[] { OleDbType.WChar, OleDbType.Integer, OleDbType.Boolean, OleDbType.Currency, OleDbType.Date, OleDbType.Binary };

        //If value is Integer or DateTime respresented with empty string then returns 0 or Time Now
        public static object GetSafeValue(Type type, object value)
        {
            int i;          
            DateTime dt;    
            bool b;         
            decimal d;      
            if (type == typeof(int) && !int.TryParse(value.ToString(), out i))
                return 0;
            if (type == typeof(decimal) && !decimal.TryParse(value.ToString(), out d))
                return 0m;
            else if (type == typeof(DateTime) && !DateTime.TryParse(value.ToString(), out dt))
                return DateTime.Now;
            else if (type == typeof(bool) && !bool.TryParse(value.ToString(), out b))
                return false;

            return value;
        }

        private static string[] reservedWords = new string[] { "Size", "Date", "Time", "Image", "Money" };
        public static string FixReservedWords(string commandString)
        {
            foreach (string word in reservedWords)
                commandString = commandString.Replace(word, "[" + word + "]");
            return commandString;
        }

        public static string GetSQLType(Type type)
        {
            if (type == typeof(int))
                return "LONG";
            if (type == typeof(string))
                return "VARCHAR";
            if (type == typeof(byte[]))
                return "LONGBINARY";
            if (type == typeof(DateTime))
                return "DATETIME";
            if (type == typeof(bool))
                return "BIT";
            if (type == typeof(decimal))
                return "CURRENCY";

            return "VARCHAR";
        }

        public static OleDbType GetOleDbType(Type type)
        {
            if (type == typeof(int))
                return OleDbType.Integer;
            if (type == typeof(string))
                return OleDbType.WChar;
            if (type == typeof(byte[]))
                return OleDbType.Binary;
            if (type == typeof(DateTime))
                return OleDbType.Date;
            if (type == typeof(bool))
                return OleDbType.Boolean;
            if (type == typeof(decimal))
                return OleDbType.Currency;

            return OleDbType.Error;
        }

        public static Type OleDbTypeToType(OleDbType type)
        {
            if (type == OleDbType.Integer)
                return typeof(int);
            if (type == OleDbType.WChar)
                return typeof(string);
            if (type == OleDbType.Binary)
                return typeof(byte[]);
            if (type == OleDbType.Date)
                return typeof(DateTime);
            if (type == OleDbType.Boolean)
                return typeof(bool);
            if (type == OleDbType.Currency)
                return typeof(decimal);

            return typeof(object);
        }

        public static byte[] ConvertImageToByteArray(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return converter.ConvertTo(img, typeof(byte[])) as byte[];
        }

        public static DataSet LoadDatabase()
        {
            DataSet ds = new DataSet();
            if(connection.State == ConnectionState.Closed) connection.Open();
            try
            {
                LoadDataFromDatabase(connection, ref ds);
                LoadForeignKeyRelations(connection, ref ds);

                foreach (DataTable table in ds.Tables)
                    foreach (DataColumn col in table.Columns)
                        col.DefaultValue = DBNull.Value;
                return ds;
            }
            finally { connection.Close(); }
        }

        private static void LoadDataFromDatabase(OleDbConnection con, ref DataSet ds)
        {
            DataTable dt = con.GetSchema("Tables", new string[] { null, null, null, "TABLE" });
            var tableNames = from DataRow row in dt.Rows select row["TABLE_NAME"] as string;

            foreach (string table in tableNames)
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter(@"SELECT * FROM " + table, con);
                adapter.Fill(ds, table);
                adapter.FillSchema(ds, SchemaType.Source, table);
                adapter.Dispose();
            }
        }

        private static void LoadForeignKeyRelations(OleDbConnection con, ref DataSet ds)
        {
            string[] restrictions = { null };
            DataTable dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Foreign_Keys, restrictions);

            foreach (DataRow row in dt.Rows)
            {
                ds.Relations.Add(
                    row["FK_NAME"] as string,
                    ds.Tables[row["PK_TABLE_NAME"] as string].Columns[row["PK_COLUMN_NAME"] as string],
                    ds.Tables[row["FK_TABLE_NAME"] as string].Columns[row["FK_COLUMN_NAME"] as string]);
            }
        }

        // TODO delete this test method
        private static void LoadPrimaryKeyRelations(OleDbConnection con, ref DataSet ds)
        {
            string[] restrictions = { null };
            DataTable dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Primary_Keys, restrictions);

            foreach (DataRow row in dt.Rows)
            {
                ds.Relations.Add(
                    row["FK_NAME"] as string,
                    ds.Tables[row["PK_TABLE_NAME"] as string].Columns[row["PK_COLUMN_NAME"] as string],
                    ds.Tables[row["FK_TABLE_NAME"] as string].Columns[row["FK_COLUMN_NAME"] as string]);
            }
        }
    }


    // Defining a new extension method for string which allows to use case insensitive Contains()
    public static class StringExtensions
    {
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source.IndexOf(toCheck, comp) >= 0;
        }
    }
}
