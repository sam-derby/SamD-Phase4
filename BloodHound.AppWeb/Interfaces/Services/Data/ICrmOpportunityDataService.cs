using System.Threading.Tasks;
using BloodHound.AppWeb.Models;

namespace BloodHound.AppWeb.Interfaces.Services.Data
{
    public interface ICrmOpportunityDataService
    {
        Task<ResponseModel> GetOpportunitiesByStateAccountNumberAndStartDateAsync(string state, string accountNumber, string startDate);

        Task<ResponseModel> GetOpportunitiesByStateAccountNumberAndStartDateAndEndDateAsync(string state,
            string accountNumber, string startDate, string endDate);
        Task<ResponseModel> SearchOpportunitiesByOppNumberAsync(string oppNumber);
        Task<ResponseModel> GetOpportunityByOppNumberAsync(string oppNumber);
        Task<ResponseModel> GetOpportunitiesByOppNumberAccountNumberAsync(string oppNumber, string accountNumber);
    }
}