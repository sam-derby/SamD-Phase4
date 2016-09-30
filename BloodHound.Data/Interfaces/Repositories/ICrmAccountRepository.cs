using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodHound.Data.Entities.Crm.Detail;
using BloodHound.Data.Entities.Crm.Table;
using BloodHound.Data.Entities.Mxp.Detail;

namespace BloodHound.Data.Interfaces.Repositories
{
    public interface ICrmAccountRepository
    {
        Task<IEnumerable<CrmAccountTableEntity>> GetTableEntitiesAsync(string accountName = "",
            string mxpCustomerNumber = "");

        Task<CrmAccountDetailEntity> GetCrmAccountDetailAsync(string accountNumber);
    }
}
