namespace TimeTracker.Shared.Models.TimeEntry
{

    public record struct TimeEntryCreatedRequest(int? ProjectId, DateTime Start, DateTime? End);

}
