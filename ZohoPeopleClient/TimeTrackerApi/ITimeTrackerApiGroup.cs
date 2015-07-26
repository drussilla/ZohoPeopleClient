namespace ZohoPeopleClient.TimeTrackerApi
{
    public interface ITimeTrackerApiGroup
    {
        ITimeLogApi TimeLog { get; }
    }
}