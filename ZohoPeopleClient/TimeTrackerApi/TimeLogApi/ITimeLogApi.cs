using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZohoPeopleClient.TimeTrackerApi
{
    public interface ITimeLogApi
    {
        Task<List<TimeLog>> GetAsync(
            string user,
            DateTime fromDate, 
            DateTime toDate, 
            string billingStatus = "all",
            string jobId = "all");

        Task<string> AddAsync(
            string user,
            DateTime workDate,
            string jobId,
            TimeSpan hours,
            string billingStatus);

        Task<bool> DeleteAsync(string timeLogId);
    }
}