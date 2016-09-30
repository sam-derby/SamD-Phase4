using System;
using System.Linq;
using System.Threading.Tasks;
using BloodHound.AppWeb.Interfaces.Services.Data;
using BloodHound.AppWeb.Models;
using BloodHound.Core.Logging;
using BloodHound.Data.Interfaces.Repositories;

namespace BloodHound.AppWeb.Services.Data
{
    public class CrmCaseDataService : DataService, ICrmCaseDataService
    {
        readonly ICrmCaseRepository _crmCaseRepository;
        readonly ICrmActivityRepository _crmActivityRepository;

        public CrmCaseDataService(ICrmCaseRepository crmCaseRepository, ICrmActivityRepository crmActivityRepository, ILogWriter logWriter):base(logWriter)
        {
            _crmCaseRepository = crmCaseRepository;
            _crmActivityRepository = crmActivityRepository;
        }

        async public Task<ResponseModel> GetCasesByStateAccountNumberAndStartDateAsync(int state, string accountNumber, DateTime startDate)
        {
            var accountId = new Guid(accountNumber);
            return await FecthDataAsync(async () =>
            {
                var data = await _crmCaseRepository.GetTableEntitiesAsync(state, accountId, startDate);
                HasData = data.Any();
                return new ResponseModel { Data = data, Message = HasData ? string.Empty : 
                    string.Format("No CRM cases found for state {0}, account number {1} and since {2}", 
                    state, accountNumber,startDate.ToString("dd MM yyy")), ResponseCode = HasData ? 200 : 204 };
            });
        }

        async public Task<ResponseModel> GetCaseByCaseNumberAsync(string caseNumber)
        {
            return await FecthDataAsync(async () =>
            {
                var data = await _crmCaseRepository.GetCrmAccountDetailAsync(caseNumber);
                HasData = data != null;
                return new ResponseModel { Data = data, Message = HasData ? string.Empty : 
                    string.Format("No Case found for case number {0}", caseNumber), ResponseCode = HasData ? 200 : 404 };
            });
        }

        async public Task<ResponseModel> GetActivitiesByStateAccountIdtartDateAndRegardingTypepeCodeAsync(int state, string accountNumber, DateTime startDate, int regardingTypeCode)
        {
            var accountId = new Guid(accountNumber);
            return await FecthDataAsync(async () =>
            {
                var data = await _crmActivityRepository.GetTableEntitiesAsync(state, accountId, startDate, regardingTypeCode);
                HasData = data.Any();
                return new ResponseModel
                {
                    Data = data,
                    Message = HasData ? string.Empty :
                    string.Format("No CRM activities found for state {0}, account number {1} and since {2}",
                    state, accountNumber, startDate.ToString("dd MM yyy")),
                    ResponseCode = HasData ? 200 : 204
                };
            });
        }
    }
}