using Mapster;
using TimeTracker.API.Repositories;
using TimeTracker.Shared.Entities;
using TimeTracker.Shared.Exceptions;
using TimeTracker.Shared.Models.TimeEntry;

namespace TimeTracker.API.Services
{
    public class TimeEntryServices : ITimeEntryServices
    {
        private readonly ITimeEntryRepository _timeEntryRepo;

        public TimeEntryServices(ITimeEntryRepository timeEntryRepo)
        {
            _timeEntryRepo = timeEntryRepo;
        }

        public async Task<List<TimeEntryResponse>> CreateTimeEntry(TimeEntryCreatedRequest request)
        {
            var newEntry = request.Adapt<TimeEntry>();

            var result = await _timeEntryRepo.CreateTimeEntry(newEntry);

            return result.Adapt<List<TimeEntryResponse>>();
        }

        public async Task<List<TimeEntryResponse>?> DeleteTimeEntry(int id)
        {
            var result = await _timeEntryRepo.DeleteTimeEntry(id);

            if (result is null) return null;

            return result.Adapt<List<TimeEntryResponse>>();

        }

        public async Task<List<TimeEntryResponse>> GetAllTimeEntries()
        {
            var result = await _timeEntryRepo.GetAllTimeEntries();

            return result.Adapt<List<TimeEntryResponse>>();
        }

        public async Task<TimeEntryResponse?> GetTimeEntryById(int id)
        {
            var result = await _timeEntryRepo.GetTimeEntryById(id);

            if (result is null) return null;

            return result.Adapt<TimeEntryResponse>();
        }

        public async Task<List<TimeEntryResponse>?> UpdateTimeEntry(int id, TimeEntryUpdateRequest timeEntry)
        {

            try
            {
                var updatedEntry = timeEntry.Adapt<TimeEntry>();

                var result = await _timeEntryRepo.UpdateTimeEntry(id, updatedEntry);

                return result.Adapt<List<TimeEntryResponse>>();

            }
            catch (EntityNotFoundException)
            {
                return null;
            }

        }
    }
}
