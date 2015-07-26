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

        string Add(
            string user,
            DateTime workDate,
            string jobId,
            TimeSpan hours,
            string billingStatus);

        bool Delete(string timeLogId);
    }
}