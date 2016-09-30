using System;
using System.Threading.Tasks;
using BloodHound.AppWeb.Models;

namespace BloodHound.AppWeb.Interfaces.Services.Data
{
    public interface ICrmCaseDataService
    {
        Task<ResponseModel> GetCasesByStateAccountNumberAndStartDateAsync(int state, string accountNumber, DateTime startDate);
        Task<ResponseModel> GetCaseByCaseNumberAsync(string caseNumber);
    }
}