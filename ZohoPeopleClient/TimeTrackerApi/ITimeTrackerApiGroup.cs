using ZohoPeopleClient.TimeTrackerApi.JobsApi;

namespace ZohoPeopleClient.TimeTrackerApi
{
    public interface ITimeTrackerApiGroup
    {
        ITimeLogApi TimeLog { get; }

        IJobsApi Jobs { get; }
    }
}