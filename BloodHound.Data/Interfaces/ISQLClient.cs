using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BloodHound.Data.Interfaces
{
    public interface ISQLClient
    {
        Task<DataTable> ExecuteReaderSpAsync(string storedProcedure, SqlParameter[] parametersCollection);
    }
}