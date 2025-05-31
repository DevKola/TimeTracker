using Microsoft.AspNetCore.Mvc;
using TimeTracker.API.Services;
using TimeTracker.Shared.Models.TimeEntry;

namespace TimeTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeEntryController : ControllerBase
    {
        private readonly ITimeEntryServices _timeEntryServices;

        public TimeEntryController(ITimeEntryServices timeEntryServices)
        {
            _timeEntryServices = timeEntryServices;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TimeEntryResponse>> GetTimeEntryById(int id)
        {
            var result = await _timeEntryServices.GetTimeEntryById(id);

            if (result is null)
            {
                return NotFound("Time entry with the given Id not found");
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<TimeEntryResponse>>> GetAllTimeEntries()
        {
            return Ok(await _timeEntryServices.GetAllTimeEntries());
        }

        [HttpGet("project/{projectId}")]
        public async Task<ActionResult<List<TimeEntryByProjectResponse>>> GetTimeEntriesByProject(int projectId)
        {
            return Ok(await _timeEntryServices.GetTimeEntriesByProject(projectId));
        }

        [HttpPost]
        public async Task<ActionResult<List<TimeEntryResponse>>> CreateTimeEntry(TimeEntryCreatedRequest timeEntry)
        {

            return Ok(await _timeEntryServices.CreateTimeEntry(timeEntry));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<TimeEntryResponse>>> UpadteTimeEntry(int id, TimeEntryUpdateRequest timeEntry)
        {
            var result = await _timeEntryServices.UpdateTimeEntry(id, timeEntry);
            if (result is null)
            {
                return NotFound("Time entry with the given Id not found");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TimeEntryResponse>>> DeleteTimeEntry(int id)
        {
            var result = await _timeEntryServices.DeleteTimeEntry(id);

            if (result is null) return NotFound("Time entry with the given Id not found");

            return Ok(result);
        }
    }
}
