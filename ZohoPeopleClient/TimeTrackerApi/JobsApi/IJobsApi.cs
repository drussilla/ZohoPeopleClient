using System.Collections.Generic;
using System.Threading.Tasks;
using ZohoPeopleClient.Model.TimeTrackerApi;

namespace ZohoPeopleClient.TimeTrackerApi.JobsApi
{
    public interface IJobsApi
    {
        Task<List<Job>> GetAsync();
    }
}