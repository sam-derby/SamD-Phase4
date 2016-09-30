using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BloodHound.AppWeb.Models;
using BloodHound.Core.Logging;

namespace BloodHound.AppWeb.Services.Data
{
    public abstract class DataService
    {
        private readonly ILogWriter _logWriter;
        protected bool HasData;

        protected DataService(ILogWriter logWriter)
        {
            _logWriter = logWriter;
        }

        async protected Task<ResponseModel> FecthDataAsync(Func<Task<ResponseModel>> dataFetcher)
        {
            try
            {
                return await dataFetcher();
            }
            catch (Exception ex)
            {
                var id = Guid.NewGuid();
                await _logWriter.LogErrorAsync(id, LogType.DataAccessError, ex.Message, ex.StackTrace);
                return new ResponseModel
                {
                    ResponseCode = 500,
                    Message =
                        string.Format(
                            "An internal server error occurred while retrieving data, please try again, if the problem persists please notify support with this Id {0}",
                            id)
                };
            }
        }
    }
}