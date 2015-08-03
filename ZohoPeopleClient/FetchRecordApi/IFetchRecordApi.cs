using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZohoPeopleClient.FetchRecordApi
{
    public interface IFetchRecordApi
    {
        Task<List<dynamic>> GetAsync(string viewName);
    }
}