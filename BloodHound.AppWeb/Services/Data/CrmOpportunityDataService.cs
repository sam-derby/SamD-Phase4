using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BloodHound.AppWeb.Interfaces.Services.Data;
using BloodHound.AppWeb.Models;
using BloodHound.Core.Logging;
using BloodHound.Data.Interfaces.Repositories;

namespace BloodHound.AppWeb.Services.Data
{
    public class CrmOpportunityDataService : DataService, ICrmOpportunityDataService
    {
        private readonly ICrmOpportunityRepository _crmOpportunityRepository;

        public CrmOpportunityDataService(ICrmOpportunityRepository crmOpportunityRepository, ILogWriter logWriter) : base(logWriter)
        {
            _crmOpportunityRepository = crmOpportunityRepository;
        }

        async public Task<ResponseModel> GetOpportunitiesByStateAccountNumberAndStartDateAsync(string state, string accountNumber, string startDate)
        {
            var start = DateTime.Parse(startDate);
            return await FecthDataAsync(async () =>
            {
                var data = await _crmOpportunityRepository.GetTableEntitiesAsync(state, start, accountId:new Guid(accountNumber));
                HasData = data.Any();
                return new ResponseModel
                {
                    Data = data,
                    Message = HasData ? string.Empty :
                    string.Format("No CRM opportunities found for state {0}, account number {1} and since {2}", state, accountNumber, start.ToString("dd MM yyy")),
                    ResponseCode = HasData ? 200 : 204
                };
            });
        }

        async public Task<ResponseModel> GetOpportunitiesByStateAccountNumberAndStartDateAndEndDateAsync(string state, string accountNumber, string startDate, string endDate)
        {
            var start = DateTime.Parse(startDate);
            var end = DateTime.Parse(endDate);
            return await FecthDataAsync(async () =>
            {
                var data = await _crmOpportunityRepository.GetTableEntitiesAsync(state, start, end, accountId: new Guid(accountNumber));
                HasData = data.Any();
                return new ResponseModel
                {
                    Data = data,
                    Message = HasData ? string.Empty :
                    string.Format("No CRM opportunities found for state {0}, account number {1} from {2} to {3}", state, accountNumber, start.ToString("dd MM yyy"), end.ToString("dd MM yyy")),
                    ResponseCode = HasData ? 200 : 204
                };
            });
        }

        async public Task<ResponseModel> SearchOpportunitiesByOppNumberAsync(string oppNumber)
        {
            return await FecthDataAsync(async () =>
            {
                var data = await _crmOpportunityRepository.GetTableEntitiesAsync(oppNumber:oppNumber);
                HasData = data.Any();
                return new ResponseModel
                {
                    Data = data,
                    Message = HasData ? string.Empty :
                    string.Format("No CRM opportunities found for opportunity number {0}" ,oppNumber),
                    ResponseCode = HasData ? 200 : 204
                };
            });
        }

        async public Task<ResponseModel> GetOpportunitiesByOppNumberAccountNumberAsync(string oppNumber, string accountNumber)
        {
            return await FecthDataAsync(async () =>
            {
                var data = await _crmOpportunityRepository.GetTableEntitiesAsync(oppNumber: oppNumber, accountId:new Guid(accountNumber));
                HasData = data.Any();
                return new ResponseModel
                {
                    Data = data,
                    Message = HasData ? string.Empty :
                    string.Format("No CRM opportunities found for opportunity number {0}", oppNumber),
                    ResponseCode = HasData ? 200 : 204
                };
            });
        }

        async public Task<ResponseModel> GetOpportunityByOppNumberAsync(string oppNumber)
        {
            return await FecthDataAsync(async () =>
            {
                var data = await _crmOpportunityRepository.GetDetailEntityAsync(oppNumber);
                HasData = data != null;
                return new ResponseModel { Data = data, Message = HasData ? string.Empty : string.Format("No opportunity found for opportunity number {0}", oppNumber), ResponseCode = HasData ? 200 : 404 };
            });
        }
    }
}