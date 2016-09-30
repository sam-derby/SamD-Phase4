using Microsoft.SharePoint.Client;

namespace BloodHound.AppWeb.Interfaces.Providers
{
    public interface ISharepointClientContextProvider
    {
        ClientContext GetClientContext();
    }
}