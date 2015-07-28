using System;
using System.Threading.Tasks;

namespace ZohoPeopleClient
{
    public interface IRestClient : IDisposable
    {
        Task<string> GetAsync(string uri);

        Task<string> PostAsync(string uri);
    }
}