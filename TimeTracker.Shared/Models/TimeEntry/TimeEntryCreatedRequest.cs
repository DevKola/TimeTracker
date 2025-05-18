namespace TimeTracker.Shared.Models.TimeEntry
{
    public class TimeEntryCreatedRequest
    {
        public required string Project { get; set; }

        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }
    }
}
