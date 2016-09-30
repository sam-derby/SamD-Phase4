using System.Collections.Generic;

namespace BloodHound.AppWeb.Interfaces.Services
{
    public interface ISharepointListService
    {
        string GetFunderForCode(string code);
        Dictionary<string, string> GetFunders();
    }
}