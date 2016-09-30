using System.Collections.Generic;
using System.Threading.Tasks;
using BloodHound.Data.Entities.Mxp.Detail;
using BloodHound.Data.Entities.Mxp.Table;

namespace BloodHound.Data.Interfaces.Repositories
{
    public interface IMxpContractsRepository
    {
        Task<IEnumerable<MxpContractHeaderTableEntity>> GetContractHeaderTableEntitiesAsync(string custNumber);

        Task<IEnumerable<MxpContractLinesTableEntity>> GetContractLinesTableEntitiesAsync(string contractNumber,string customerNumber);
        Task<MxpContractLinesDetailEntity> GetContractLineDetailEntityAsync(string custNumber, string contractNumber, string lineNumber);
        Task<IEnumerable<MxpContractHeaderTableEntity>> SearchContractHeaderTableEntitiesAsync(string custNumber);

        Task<IEnumerable<MxpContractLineCategoryTableEntity>> GetContractLineCategoryTableEntitiesAsync(
            string contractNumber, decimal lineNumber);


    }
}