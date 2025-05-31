using Microsoft.EntityFrameworkCore;
using TimeTracker.API.Data;
using TimeTracker.Shared.Entities;
using TimeTracker.Shared.Exceptions;

namespace TimeTracker.API.Repositories
{
    public class TimeEntryRepository : ITimeEntryRepository
    {

        private readonly DataContext _context;

        public TimeEntryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<TimeEntry>?> DeleteTimeEntry(int id)
        {
            var dbTimeEntry = await _context.TimeEntries.FindAsync(id);

            if (dbTimeEntry == null)
            {
                return null;
            }
            _context.TimeEntries.Remove(dbTimeEntry);

            await _context.SaveChangesAsync();

            return await GetAllTimeEntries();
        }

        public async Task<TimeEntry?> GetTimeEntryById(int id)
        {
            var timeEntry = await _context.TimeEntries
                .Include(te => te.Project)
                .FirstOrDefaultAsync(te => te.Id == id);

            return timeEntry;
        }

        public async Task<List<TimeEntry>?> UpdateTimeEntry(int id, TimeEntry timeEntry)
        {

            var dbTimeEntry = await _context.TimeEntries.FindAsync(id);

            if (dbTimeEntry is null)
            {
                throw new EntityNotFoundException($"Entity wih the Id {id} was not found.");
            }

            dbTimeEntry.ProjectId = timeEntry.ProjectId;
            dbTimeEntry.End = timeEntry.End;
            dbTimeEntry.Start = timeEntry.Start;
            dbTimeEntry.DateUpdated = timeEntry.DateUpdated;

            await _context.SaveChangesAsync();

            return await GetAllTimeEntries();
        }



        public async Task<List<TimeEntry>> CreateTimeEntry(TimeEntry timeEntry)
        {
            _context.TimeEntries.Add(timeEntry);

            await _context.SaveChangesAsync();

            return await GetAllTimeEntries();
        }

        public async Task<List<TimeEntry>> GetAllTimeEntries()
        {
            return await _context.TimeEntries
                .Include(te => te.Project)
                .ToListAsync();
        }

        public async Task<List<TimeEntry>> GetTimeEntryByProject(int projectId)
        {
            return await _context.TimeEntries
                .Where(te => te.ProjectId == projectId)
                .ToListAsync();
        }
    }
}
