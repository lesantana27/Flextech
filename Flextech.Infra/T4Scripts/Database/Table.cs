using System;
using System.Collections.Generic;
using System.Text;

namespace Flextech.Infra.T4Scripts.Database
{
    public class Table
    {
        public string Name { get; set; } = "";

        public string Schema { get; set; } = "";

        public List<Flextech.Infra.T4Scripts.Database.Column> Columns { get; set; } = new List<Flextech.Infra.T4Scripts.Database.Column>();

        public int TotalColumns { get { return Columns.Count; } }

    }
}
