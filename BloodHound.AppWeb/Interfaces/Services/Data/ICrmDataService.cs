using System.Threading.Tasks;
using BloodHound.AppWeb.Models;
using Microsoft.SharePoint.Client;

namespace BloodHound.AppWeb.Interfaces.Services.Data
{
    public interface ICrmDataService
    {
        Task<ResponseModel> SearchByCustomerNameAsync(string accountName);
        Task<ResponseModel> GetAccountAsync(string accountNumber);
        Task<ResponseModel> GetMxpCrmRecordsAsync(string custNumber);
        Task<ResponseModel> GetCrmContactsAsync(string accountNumber);
        Task<ResponseModel> GetCrmDevicesByMxpCustomerNumberAsync(string customerNumber);
        Task<ResponseModel> GetDevicesByAccountNumberAsync(string accountNumber);
        Task<ResponseModel> GetDeviceByDeviceIdAsync(string deviceId);
        Task<ResponseModel> GetDeviceBySysRefAsync(string systemRef);
        Task<ResponseModel> GetDeviceAndStatusBySysRefAsync(string systemRef);
    }
}