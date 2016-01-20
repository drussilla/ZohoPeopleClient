using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZohoPeopleClient.FetchRecordApi
{
    public interface IFetchRecordApi
    {
        Task<List<dynamic>> GetByViewAsync(string viewName);

        Task<List<dynamic>> GetByFormAsync(string formName);
    }
}