using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using ZohoPeopleClient.JsonConverters;

namespace ZohoPeopleClient.Model.TimeTrackerApi
{
    public class Job
    {
        [JsonConverter(typeof(TimeJsonConverter))]
        public Time TotalHours { get; set; }
        public string JobId { get; set; }
        public string JobName { get; set; }
        public string AssignedBy { get; set; }
        public string Hours { get; set; }
        public string Description { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string ProjectId { get; set; }
        public string ProjectName { get; set; }
        protected float RatePerHour { get; set; }
        public List<Assignee> Assignees { get; set; }
    }
}