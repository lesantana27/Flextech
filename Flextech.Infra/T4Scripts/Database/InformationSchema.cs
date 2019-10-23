using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flextech.Infra.T4Scripts.Database
{
    public class InformationSchema
    {
        public List<Flextech.Infra.T4Scripts.Database.InformationSchema.ColumnModel> Columns { get; set; }

        #region Column Model

        /*
        TABLE_CATALOG
        TABLE_SCHEMA
        TABLE_NAME
        COLUMN_NAME
        ORDINAL_POSITION
        COLUMN_DEFAULT
        IS_NULLABLE
        DATA_TYPE
        CHARACTER_MAXIMUM_LENGTH
        NUMERIC_PRECISION
        NUMERIC_PRECISION_RADIX
        NUMERIC_SCALE
        DATETIME_PRECISION
        CHARACTER_SET_CATALOG
        CHARACTER_SET_SCHEMA
        CHARACTER_SET_NAME
        COLLATION_CATALOG
        COLLATION_SCHEMA
        COLLATION_NAME
        DOMAIN_CATALOG
        DOMAIN_SCHEMA
        DOMAIN_NAME
        */

        public class ColumnModel
        {
            public string TABLE_CATALOG { get; set; }
            public string TABLE_SCHEMA { get; set; }
            public string TABLE_NAME { get; set; }
            public string COLUMN_NAME { get; set; }
            public int ORDINAL_POSITION { get; set; }
            public string COLUMN_DEFAULT { get; set; }
            public string IS_NULLABLE { get; set; }
            public string DATA_TYPE { get; set; }
            public int CHARACTER_MAXIMUM_LENGTH { get; set; }
            public int NUMERIC_PRECISION { get; set; }
            public int NUMERIC_PRECISION_RADIX { get; set; }
            public int NUMERIC_SCALE { get; set; }
            public int DATETIME_PRECISION { get; set; }
            public string CHARACTER_SET_CATALOG { get; set; }
            public string CHARACTER_SET_SCHEMA { get; set; }
            public string CHARACTER_SET_NAME { get; set; }
            public string COLLATION_CATALOG { get; set; }
            public string COLLATION_SCHEMA { get; set; }
            public string COLLATION_NAME { get; set; }
            public string DOMAIN_CATALOG { get; set; }
            public string DOMAIN_SCHEMA { get; set; }
            public string DOMAIN_NAME { get; set; }

        }

        #endregion Column Model
    }
}
