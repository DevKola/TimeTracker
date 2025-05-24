using TimeTracker.Shared.Models.TimeEntry;

namespace TimeTracker.API.Services
{
    public interface ITimeEntryServices
    {
        Task<List<TimeEntryResponse>> GetAllTimeEntries();

        Task<TimeEntryResponse?> GetTimeEntryById(int id);

        Task<List<TimeEntryResponse>> CreateTimeEntry(TimeEntryCreatedRequest timeEntry);

        Task<List<TimeEntryResponse>?> UpdateTimeEntry(int id, TimeEntryUpdateRequest timeEntry);

        Task<List<TimeEntryResponse>?> DeleteTimeEntry(int id);
    }
}
