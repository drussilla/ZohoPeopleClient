using System;

namespace ZohoPeopleClient.Model.LeaveApi
{
    public class Holiday
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LocationId { get; set; }
        public string LocationName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Remarks { get; set; }
    }
}