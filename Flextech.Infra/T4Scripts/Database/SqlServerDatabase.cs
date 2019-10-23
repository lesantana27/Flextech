using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;

namespace Flextech.Infra.T4Scripts.Database
{
    public class SqlServerDatabase : Flextech.Infra.T4Scripts.Database.Database
    {
        private string connectionString = "";

        public InformationSchema InformationSchema { get; set; }

        public SqlServerDatabase(string connectionString)
        {
            if (connectionString == "")
                throw new Exception("ConnectionString is empty");

            this.connectionString = connectionString;

            FillAll();
        }

        #region Protected Override Methods

        protected override DataTable GetAllTables()
        {
            string query = @"   select	TABLE_CATALOG, TABLE_SCHEMA, TABLE_NAME, TABLE_TYPE 
                                from	INFORMATION_SCHEMA.TABLES 
                                where	TABLE_TYPE = 'BASE TABLE'
                                and     TABLE_NAME <> 'sysdiagrams'
                                order	by TABLE_SCHEMA, TABLE_NAME";

            return ExecuteQuery(query);
        }

        protected override DataTable GetAllViews()
        {
            string query = @"   select	TABLE_CATALOG, TABLE_SCHEMA, TABLE_NAME, TABLE_TYPE 
                                from	INFORMATION_SCHEMA.TABLES 
                                where	TABLE_TYPE = 'VIEW'
                                order	by TABLE_SCHEMA, TABLE_NAME";

            return ExecuteQuery(query);
        }

        protected override DataTable GetAllColumns()
        {
            string query = @"select distinct  
		                            a.TABLE_SCHEMA,
                                    a.TABLE_NAME, 
                                    a.COLUMN_NAME, 
                                    a.ORDINAL_POSITION, 
                                    a.DATA_TYPE, 
                                    isnull(a.CHARACTER_MAXIMUM_LENGTH, 0) as CHARACTER_MAXIMUM_LENGTH,
		                            CASE WHEN b.COLUMN_NAME IS NOT NULL THEN 1 ELSE 0 END as PRIMARY_KEY
                            from    INFORMATION_SCHEMA.COLUMNS a
                            left	join INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE as b
		                            on	a.TABLE_NAME = b.TABLE_NAME
		                            and	a.COLUMN_NAME = b.COLUMN_NAME
                            left	join INFORMATION_SCHEMA.TABLE_CONSTRAINTS as c
		                            on	a.TABLE_NAME = c.TABLE_NAME
		                            and	b.CONSTRAINT_NAME = c.CONSTRAINT_NAME
		                            and c.CONSTRAINT_TYPE = 'PRIMARY KEY'
                            where   a.TABLE_NAME <> 'sysdiagrams' 
                            order   by a.TABLE_SCHEMA, a.TABLE_NAME, a.ORDINAL_POSITION, a.COLUMN_NAME";

            return ExecuteQuery(query);
        }

        public override DataTable ExecuteQuery(string query)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }


        #endregion #region Protected Override Methods


        protected DataTable GetInformationSchemaAllColumns()
        {
            string query =
                @"
                select
		                ISNULL(TABLE_CATALOG					, '') as TABLE_CATALOG,
		                ISNULL(TABLE_SCHEMA						, '') as TABLE_SCHEMA,
		                ISNULL(TABLE_NAME						, '') as TABLE_NAME,
		                ISNULL(COLUMN_NAME						, '') as COLUMN_NAME,
		                ISNULL(ORDINAL_POSITION					, 00) as ORDINAL_POSITION,
		                ISNULL(COLUMN_DEFAULT					, '') as COLUMN_DEFAULT,
		                ISNULL(IS_NULLABLE						, '') as IS_NULLABLE,
		                ISNULL(DATA_TYPE						, '') as DATA_TYPE,
		                ISNULL(CHARACTER_MAXIMUM_LENGTH			, 00) as CHARACTER_MAXIMUM_LENGTH,
		                ISNULL(NUMERIC_PRECISION				, 00) as NUMERIC_PRECISION,
		                ISNULL(NUMERIC_PRECISION_RADIX			, 00) as NUMERIC_PRECISION_RADIX,
		                ISNULL(NUMERIC_SCALE					, 00) as NUMERIC_SCALE,
		                ISNULL(DATETIME_PRECISION				, 00) as DATETIME_PRECISION,
		                ISNULL(CHARACTER_SET_CATALOG			, '') as CHARACTER_SET_CATALOG,
		                ISNULL(CHARACTER_SET_SCHEMA				, '') as CHARACTER_SET_SCHEMA,
		                ISNULL(CHARACTER_SET_NAME				, '') as CHARACTER_SET_NAME,
		                ISNULL(COLLATION_CATALOG				, '') as COLLATION_CATALOG,
		                ISNULL(COLLATION_SCHEMA					, '') as COLLATION_SCHEMA,
		                ISNULL(COLLATION_NAME					, '') as COLLATION_NAME,
		                ISNULL(DOMAIN_CATALOG					, '') as DOMAIN_CATALOG,
		                ISNULL(DOMAIN_SCHEMA					, '') as DOMAIN_SCHEMA,
		                ISNULL(DOMAIN_NAME						, '') as DOMAIN_NAME
                FROM	INFORMATION_SCHEMA.COLUMNS
                WHERE	TABLE_NAME <> 'sysdiagrams'
                ORDER	BY DATA_TYPE, COLUMN_NAME
                ";

            return ExecuteQuery(query);
        }

        private void FillAll()
        {
            Tables = new List<Flextech.Infra.T4Scripts.Database.Table>();
            Views = new List<Flextech.Infra.T4Scripts.Database.Table>();

            DataTable dtColumns = GetAllColumns();

            FillTableOrView(Tables, GetAllTables(), dtColumns);
            FillTableOrView(Views, GetAllViews(), dtColumns);

            FillInformationSchemaColumns();
        }

        private void FillTableOrView(List<Flextech.Infra.T4Scripts.Database.Table> tableOrView, DataTable dt, DataTable dtColumns)
        {
            Flextech.Infra.T4Scripts.Database.Table t;
            Flextech.Infra.T4Scripts.Database.Column c;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                t = new Table();
                t.Name = dt.Rows[i]["TABLE_NAME"].ToString();
                t.Schema = dt.Rows[i]["TABLE_SCHEMA"].ToString();
                t.Columns = new List<Column>();

                for (int j = 0; j < dtColumns.Rows.Count; j++)
                {
                    if (dtColumns.Rows[j]["TABLE_SCHEMA"].ToString() == t.Schema && dtColumns.Rows[j]["TABLE_NAME"].ToString() == t.Name)
                    {
                        c = new Column();

                        c.Name = dtColumns.Rows[j]["COLUMN_NAME"].ToString();
                        c.Position = dtColumns.Rows[j]["ORDINAL_POSITION"].ToString();
                        c.Type = dtColumns.Rows[j]["DATA_TYPE"].ToString();
                        c.Size = dtColumns.Rows[j]["CHARACTER_MAXIMUM_LENGTH"].ToString();
                        c.PrimaryKey = false;
                        c.ForeignKey = false;

                        if (c.Name.Length > 3)
                            if (c.Name.StartsWith("ID_"))
                                if (c.Name.Substring(3) == t.Name)
                                    c.PrimaryKey = true;
                                else
                                    c.ForeignKey = true;

                        t.Columns.Add(c);
                    }
                }

                tableOrView.Add(t);
            }
        }

        private void FillInformationSchemaColumns()
        {
            DataTable dtColumns = GetInformationSchemaAllColumns();
            Flextech.Infra.T4Scripts.Database.InformationSchema.ColumnModel c;

            InformationSchema = new InformationSchema();

            InformationSchema.Columns = new List<Flextech.Infra.T4Scripts.Database.InformationSchema.ColumnModel>();

            for (int i = 0; i < dtColumns.Rows.Count; i++)
            {
                c = new Flextech.Infra.T4Scripts.Database.InformationSchema.ColumnModel();

                c.TABLE_CATALOG = dtColumns.Rows[i]["TABLE_CATALOG"].ToString();
                c.TABLE_SCHEMA = dtColumns.Rows[i]["TABLE_SCHEMA"].ToString();
                c.TABLE_NAME = dtColumns.Rows[i]["TABLE_NAME"].ToString();
                c.COLUMN_NAME = dtColumns.Rows[i]["COLUMN_NAME"].ToString();
                c.ORDINAL_POSITION = Convert.ToInt32(dtColumns.Rows[i]["ORDINAL_POSITION"].ToString());
                c.COLUMN_DEFAULT = dtColumns.Rows[i]["COLUMN_DEFAULT"].ToString();
                c.IS_NULLABLE = dtColumns.Rows[i]["IS_NULLABLE"].ToString();
                c.DATA_TYPE = dtColumns.Rows[i]["DATA_TYPE"].ToString();
                c.CHARACTER_MAXIMUM_LENGTH = Convert.ToInt32(dtColumns.Rows[i]["CHARACTER_MAXIMUM_LENGTH"].ToString());
                c.NUMERIC_PRECISION = Convert.ToInt32(dtColumns.Rows[i]["NUMERIC_PRECISION"].ToString());
                c.NUMERIC_PRECISION_RADIX = Convert.ToInt32(dtColumns.Rows[i]["NUMERIC_PRECISION_RADIX"].ToString());
                c.NUMERIC_SCALE = Convert.ToInt32(dtColumns.Rows[i]["NUMERIC_SCALE"].ToString());
                c.DATETIME_PRECISION = Convert.ToInt32(dtColumns.Rows[i]["DATETIME_PRECISION"].ToString());
                c.CHARACTER_SET_CATALOG = dtColumns.Rows[i]["CHARACTER_SET_CATALOG"].ToString();
                c.CHARACTER_SET_SCHEMA = dtColumns.Rows[i]["CHARACTER_SET_SCHEMA"].ToString();
                c.CHARACTER_SET_NAME = dtColumns.Rows[i]["CHARACTER_SET_NAME"].ToString();
                c.COLLATION_CATALOG = dtColumns.Rows[i]["COLLATION_CATALOG"].ToString();
                c.COLLATION_SCHEMA = dtColumns.Rows[i]["COLLATION_SCHEMA"].ToString();
                c.COLLATION_NAME = dtColumns.Rows[i]["COLLATION_NAME"].ToString();
                c.DOMAIN_CATALOG = dtColumns.Rows[i]["DOMAIN_CATALOG"].ToString();
                c.DOMAIN_SCHEMA = dtColumns.Rows[i]["DOMAIN_SCHEMA"].ToString();
                c.DOMAIN_NAME = dtColumns.Rows[i]["DOMAIN_NAME"].ToString();

                InformationSchema.Columns.Add(c);
            }
        }









        private void teste()
        {
            Table table = this.Tables.Find(a => a.Name == "NOME DA TABELA");

            


        }


    }
}
