using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZohoPeopleClient.FetchRecordApi
{
    public interface IFetchRecordApi
    {
        Task<List<dynamic>> GetByViewAsync(string viewName);

        Task<List<dynamic>> GetByViewAsync(string viewName, SearchColumn searchColumn, string searchValue);

        Task<List<dynamic>> GetByFormAsync(string formName);

        Task<List<dynamic>> GetByFormAsync(string formName, SearchColumn searchColumn, string searchValue);
    }
}