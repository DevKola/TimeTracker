using TimeTracker.Shared.Entities;

namespace TimeTracker.API.Repositories
{
    public interface ITimeEntryRepository
    {
        Task<List<TimeEntry>> GetAllTimeEntries();

        Task<TimeEntry?> GetTimeEntryById(int id);

        Task<List<TimeEntry>> CreateTimeEntry(TimeEntry timeEntry);

        Task<List<TimeEntry>?> UpdateTimeEntry(int id, TimeEntry timeEntry);

        Task<List<TimeEntry>?> DeleteTimeEntry(int id);
    }
}
