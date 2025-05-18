using TimeTracker.Shared.Models.TimeEntry;

namespace TimeTracker.API.Services
{
    public interface ITimeEntryServices
    {
        List<TimeEntryResponse> GetAllTimeEntries();

        TimeEntryResponse? GetTimeEntryById(int id);

        List<TimeEntryResponse> CreateTimeEntry(TimeEntryCreatedRequest timeEntry);

        List<TimeEntryResponse>? UpdateTimeEntry(int id, TimeEntryUpdateRequest timeEntry);

        List<TimeEntryResponse>? DeleteTimeEntry(int id);
    }
}
