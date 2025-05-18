using TimeTracker.Shared.Entities;

namespace TimeTracker.API.Repositories
{
    public class TimeEntryRepository : ITimeEntryRepository
    {
        private static List<TimeEntry> _timeEntries = new List<TimeEntry>
        {
            new TimeEntry
            {
                Id = 1,
                Project = "Time Entry",
                End = DateTime.Now.AddHours(1),
            }
        };

        public List<TimeEntry>? DeleteTimeEntry(int id)
        {
            var entryToDelete = _timeEntries.FirstOrDefault(t => t.Id == id);
            if (entryToDelete == null)
            {
                return null;
            }
            _timeEntries.Remove(entryToDelete);
            return _timeEntries;
        }

        public TimeEntry? GetTimeEntryById(int id)
        {
            return _timeEntries.FirstOrDefault(t => t.Id == id);
        }

        public List<TimeEntry>? UpdateTimeEntry(int id, TimeEntry timeEntry)
        {
            var entryToUpdate = _timeEntries.FindIndex(x => x.Id == id);
            if (entryToUpdate == -1)
            {
                return null;
            }

            _timeEntries[entryToUpdate] = timeEntry;
            return _timeEntries;
        }

        List<TimeEntry> ITimeEntryRepository.CreateTimeEntry(TimeEntry timeEntry)
        {
            _timeEntries.Add(timeEntry);
            return _timeEntries;
        }

        List<TimeEntry> ITimeEntryRepository.GetAllTimeEntries()
        {
            return _timeEntries;
        }
    }
}
