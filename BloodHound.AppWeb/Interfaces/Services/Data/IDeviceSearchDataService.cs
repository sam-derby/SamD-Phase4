using System.Threading.Tasks;
using BloodHound.AppWeb.Models;

namespace BloodHound.AppWeb.Interfaces.Services.Data
{
    public interface IDeviceSearchDataService
    {
        Task<ResponseModel> SearchByCustomerNumberAsync(string custNumber);
        Task<ResponseModel> SearchBySystemRefAsync(string sysRef);
        Task<ResponseModel> SearchBySerialNumberAsync(string serialNumber);
        Task<ResponseModel> SearchByAlternativeReferenceAsync(string altRef);
        Task<ResponseModel> SearchByLeaseIdAsync(int leaseId);
    }
}