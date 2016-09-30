using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodHound.Core.MockData;
using Newtonsoft.Json;

namespace Bloodhound.Data.Tests
{
    public static class TestHelpers
    {
        public static DataTable GetTable(string storedProcedure)
        {
            var json = MockData.StoredProcedures[storedProcedure];
            return (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
        }

        public static DataTable GetEmptyTable()
        {
            return new DataTable();
        }
    }
}
