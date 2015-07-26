using System;

namespace ZohoPeopleClient.TimeTrackerApi
{
    public class TimeTrackerApiGroup : ITimeTrackerApiGroup
    {
        internal TimeTrackerApiGroup(string token)
        {
            TimeLog = new TimeLogApi(token);
        }

        public ITimeLogApi TimeLog { get; private set; }
    }
}