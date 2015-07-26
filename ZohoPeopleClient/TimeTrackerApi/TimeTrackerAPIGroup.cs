using ZohoPeopleClient.TimeTrackerApi.JobsApi;

namespace ZohoPeopleClient.TimeTrackerApi
{
    public class TimeTrackerApiGroup : ITimeTrackerApiGroup
    {
        internal TimeTrackerApiGroup(string token)
        {
            TimeLog = new TimeLogApi(token);
            Jobs = new JobsApi.JobsApi(token);
        }

        public ITimeLogApi TimeLog { get; private set; }
        public IJobsApi Jobs { get; private set; }
    }
}