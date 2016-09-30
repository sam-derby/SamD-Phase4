using System;
using System.Threading.Tasks;
using BloodHound.AppWeb.Models;

namespace BloodHound.AppWeb.Interfaces.Services.Data
{
    public interface IMxpDataService
    {
        Task<ResponseModel> SearchByCustomerNameAsync(string custName);
        Task<ResponseModel> SearchByCustomerNumberAsync(string custNumber);
        Task<ResponseModel> GetCustomerAsync(string custNumber);
        Task<ResponseModel> GetContactsSummaryAsync(string custNumber);
        Task<ResponseModel> GetDevicesByCustomerNumberAsync(string custNumber);
        Task<ResponseModel> GetDeviceBySysRefAsync(string systemRef);
        Task<ResponseModel> GetDeviceAndStatusBySysRefAsync(string systemRef);
        Task<ResponseModel> GetContractHeadersByCustomerNumberAsync(string customerNumber);
        Task<ResponseModel> GetContractLinesByContractNumberAndCustomerNumberAsync(string contractNumber,
            string customerNumber);
        Task<ResponseModel> GetContractLineByCustomerNumberContractNumberAndLineNumberAsync(string customerNumber,
            string contractNumber, string lineNumber);

        Task<ResponseModel> GetLeaseByLeaseIdAsync(int leaseId);
        Task<ResponseModel> GetLeasesByCustomerNumberAsync(string customerNumber);
        Task<ResponseModel> SearchContractHeadersByContractNumberAsync(string contractNumber);
        Task<ResponseModel> SearchLeasesByLeaseRefAsync(string leaseRef);
        Task<ResponseModel> GetDevicesByLeaseIdAsync(int leaseId);
        Task<ResponseModel> GetLeasesByLeaseIdAsync(int leaseId);
        Task<ResponseModel> GetContractLineCategoriesByContractNumberAndLineNumberAsync(string contractNumber,
            string lineNumber);
        Task<ResponseModel> GetServiceCallsByCustomerNumberStateStartDate(string customerNumber, string startDate,
            string endDate);
        Task<ResponseModel> GetServiceCallByCustomerNumberServiceNumber(string customerNumber, string serviceNumber);
        Task<ResponseModel> SearchServiceCallsByServiceNumberAsync(string customerNumber);
        Task<ResponseModel> GetServiceCallsByCustomerNumberServiceNumber(string customerNumber, string serviceNumber);
    }
}