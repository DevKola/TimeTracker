namespace TimeTracker.Shared.Models.TimeEntry
{

    public record struct TimeEntryCreatedRequest(string Project, DateTime Start, DateTime? End);

}
