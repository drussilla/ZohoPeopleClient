using System;
using Newtonsoft.Json;
using ZohoPeopleClient.Converters;

namespace ZohoPeopleClient.Model.TimeTrackerApi
{
    public class TimeLog
    {
        public DateTime WorkDate { get; set; }
        public string JobId { get; set; }
        public string Erecno { get; set; }

        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan Hours { get; set; }

        /// <summary>
        /// In minutes
        /// </summary>
        public int FromTime { get; set; }
        public string Type { get; set; }
        public string JobName { get; set; }
        public string TaskName { get; set; }
        /// <summary>
        /// In minutes
        /// </summary>
        public int ToTime { get; set; }
        public string TimelogId { get; set; }
        public bool JobIsCompleted { get; set; }
        public string Description { get; set; }
        public bool JobIsActive { get; set; }
        public int TotalTime { get; set; }
        public string BillingStatus { get; set; }
        public bool TimerLog { get; set; }
    }
}