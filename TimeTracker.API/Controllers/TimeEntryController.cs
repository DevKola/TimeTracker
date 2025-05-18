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
        public ActionResult<TimeEntryResponse> GetTimeEntryById()
        {
            var result = _timeEntryServices.GetAllTimeEntries();

            if (result is null)
            {
                return NotFound("Time entry with the given Id not found");
            }

            return Ok(_timeEntryServices.GetAllTimeEntries());
        }

        [HttpGet]
        public ActionResult<List<TimeEntryResponse>> GetAllTimeEntries(int id)
        {
            return Ok(_timeEntryServices.GetAllTimeEntries());
        }


        [HttpPost]
        public ActionResult<List<TimeEntryResponse>> CreateTimeEntry(TimeEntryCreatedRequest timeEntry)
        {

            return Ok(_timeEntryServices.CreateTimeEntry(timeEntry));
        }

        [HttpPut("{id}")]
        public ActionResult<List<TimeEntryResponse>> UpadteTimeEntry(int id, TimeEntryUpdateRequest timeEntry)
        {
            var result = _timeEntryServices.UpdateTimeEntry(id, timeEntry);
            if (result is null)
            {
                return NotFound("Time entry with the given Id not found");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public ActionResult<List<TimeEntryResponse>> DeleteTimeEntry(int id)
        {
            var result = _timeEntryServices.DeleteTimeEntry(id);
            if (result is null) return NotFound("Time entry with the given Id not found");
            return Ok(result);
        }
    }
}
