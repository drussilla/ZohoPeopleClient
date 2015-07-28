using System;
using ZohoPeopleClient.TimeTrackerApi.JobsApi;

namespace ZohoPeopleClient.TimeTrackerApi
{
    public class TimeTrackerApiGroup : ITimeTrackerApiGroup
    {
        internal TimeTrackerApiGroup(string token, Func<IRestClient> clientFactory)
        {
            TimeLog = new TimeLogApi(token, clientFactory);
            Jobs = new JobsApi.JobsApi(token, clientFactory);
        }

        public ITimeLogApi TimeLog { get; private set; }
        public IJobsApi Jobs { get; private set; }
    }
}