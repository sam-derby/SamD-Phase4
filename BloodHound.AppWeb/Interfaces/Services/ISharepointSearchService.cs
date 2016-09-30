using Microsoft.SharePoint.Client;

namespace BloodHound.AppWeb.Interfaces.Services
{
    public interface ISharepointSearchService
    {
        string GetCrmSiteUrl(string sharepointId);
    }
}