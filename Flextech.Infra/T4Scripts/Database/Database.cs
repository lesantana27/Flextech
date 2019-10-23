using System;
using System.Collections.Generic;
using System.Data;

namespace Flextech.Infra.T4Scripts.Database
{
    public abstract class Database
    {
        public List<Flextech.Infra.T4Scripts.Database.Table> Tables { get; set; } = new List<Flextech.Infra.T4Scripts.Database.Table>();
        public List<Flextech.Infra.T4Scripts.Database.Table> Views { get; set; } = new List<Flextech.Infra.T4Scripts.Database.Table>();

        public int TotalTables { get { return Tables.Count; } }
        public int TotalViews { get { return Views.Count; } }


        protected virtual DataTable GetAllTables()
        {
            throw new NotImplementedException();
        }

        protected virtual DataTable GetAllViews()
        {
            throw new NotImplementedException();
        }

        protected virtual DataTable GetAllColumns()
        {
            throw new NotImplementedException();
        }

        public virtual DataTable ExecuteQuery(string query)
        {
            throw new NotImplementedException();
        }

    }
}
