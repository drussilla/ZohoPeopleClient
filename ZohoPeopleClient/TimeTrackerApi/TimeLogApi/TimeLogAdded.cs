namespace ZohoPeopleClient.TimeTrackerApi
{
    public class TimeLogAddedResponse : ResponseWrapper<TimeLogAdded>
    {
    }

    public class TimeLogAdded
    {
        public string TimeLogId { get; set; }
    }
}