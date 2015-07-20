using System;

namespace ZohoPeopleClient.TimeTrackerApi
{
    public class TimeTrackerApiGroup
    {
        internal TimeTrackerApiGroup(string token)
        {
            TimeLog = new TimeLogApi(token);
        }

        public TimeLogApi TimeLog { get; private set; }
    }
}