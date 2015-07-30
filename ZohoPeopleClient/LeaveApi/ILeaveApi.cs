using System.Collections.Generic;
using System.Threading.Tasks;
using ZohoPeopleClient.Model.LeaveApi;

namespace ZohoPeopleClient.LeaveApi
{
    public interface ILeaveApi
    {
        Task<List<Holiday>> GetHolidaysAsync(string userEmail);
    }
}