using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZohoPeopleClient.TimeTrackerApi.JobsApi
{
    public interface IJobsApi
    {
        Task<List<Job>> GetAsync();
    }
}