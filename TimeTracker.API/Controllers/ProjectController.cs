using Microsoft.AspNetCore.Mvc;
using TimeTracker.API.Services;
using TimeTracker.Shared.Models.Project;

namespace TimeTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectServices _projectServices;

        public ProjectController(IProjectServices projectServices)
        {
            _projectServices = projectServices;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectResponse>> GetProjectById(int id)
        {
            var result = await _projectServices.GetProjectById(id);

            if (result is null)
            {
                return NotFound("Time entry with the given Id not found");
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<ProjectResponse>>> GetAllProjects()
        {
            return Ok(await _projectServices.GetAllProjects());
        }


        [HttpPost]
        public async Task<ActionResult<List<ProjectResponse>>> CreateProject(ProjectCreatedRequest project)
        {

            return Ok(await _projectServices.CreateProject(project));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<ProjectResponse>>> UpdateProject(int id, ProjectUpdateRequest project)
        {
            var result = await _projectServices.UpdateProject(id, project);
            if (result is null)
            {
                return NotFound("Time entry with the given Id not found");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ProjectResponse>>> DeleteProject(int id)
        {
            var result = await _projectServices.DeleteProject(id);

            if (result is null) return NotFound("Time entry with the given Id not found");

            return Ok(result);
        }
    }
}
