using System.Threading.Tasks;
using ZohoPeopleClient.FetchRecordApi;
using ZohoPeopleClient.LeaveApi;
using ZohoPeopleClient.TimeTrackerApi;

namespace ZohoPeopleClient
{
    public interface IZohoClient
    {
        ITimeTrackerApiGroup TimeTracker { get; }

        ILeaveApi Leave { get; }

        IFetchRecordApi FetchRecord { get; }

        string GetWebLoginUrl();

        void Login(string token);

        Task<string> LoginAsync(string login, string password);
    }
}