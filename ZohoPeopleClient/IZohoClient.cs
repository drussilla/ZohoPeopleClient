using System.Threading.Tasks;
using ZohoPeopleClient.LeaveApi;
using ZohoPeopleClient.TimeTrackerApi;

namespace ZohoPeopleClient
{
    public interface IZohoClient
    {
        ITimeTrackerApiGroup TimeTracker { get; }

        ILeaveApi Leave { get; }

        string GetWebLoginUrl();

        void Login(string token);

        Task<string> LoginAsync(string login, string password);
    }
}