using System.Threading.Tasks;
using ZohoPeopleClient.TimeTrackerApi;

namespace ZohoPeopleClient
{
    public interface IZohoClient
    {
        TimeTrackerApiGroup TimeTracker { get; }

        string GetWebLoginUrl();

        void Login(string token);

        Task<string> LoginAsync(string login, string password);
    }
}