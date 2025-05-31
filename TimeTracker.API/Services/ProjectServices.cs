using Mapster;
using TimeTracker.API.Repositories;
using TimeTracker.Shared.Entities;
using TimeTracker.Shared.Exceptions;
using TimeTracker.Shared.Models.Project;

namespace TimeTracker.API.Services
{
    public class ProjectServices : IProjectServices
    {
        private readonly IProjectRepository _projectRepo;

        public ProjectServices(IProjectRepository projectRepo)
        {
            _projectRepo = projectRepo;
        }

        public async Task<List<ProjectResponse>> CreateProject(ProjectCreatedRequest request)
        {
            var newEntry = request.Adapt<Project>();

            newEntry.ProjectDetails = request.Adapt<ProjectDetails>();

            var result = await _projectRepo.CreateProject(newEntry);

            return result.Adapt<List<ProjectResponse>>();
        }

        public async Task<List<ProjectResponse>?> DeleteProject(int id)
        {
            var result = await _projectRepo.DeleteProject(id);

            if (result is null) return null;

            return result.Adapt<List<ProjectResponse>>();

        }

        public async Task<List<ProjectResponse>> GetAllProjects()
        {
            var result = await _projectRepo.GetAllProjects();

            return result.Adapt<List<ProjectResponse>>();
        }

        public async Task<ProjectResponse?> GetProjectById(int id)
        {
            var result = await _projectRepo.GetProjectById(id);

            if (result is null) return null;

            return result.Adapt<ProjectResponse>();
        }

        public async Task<List<ProjectResponse>?> UpdateProject(int id, ProjectUpdateRequest project)
        {

            try
            {
                var updatedEntry = project.Adapt<Project>();

                updatedEntry.ProjectDetails = project.Adapt<ProjectDetails>();


                var result = await _projectRepo.UpdateProject(id, updatedEntry);

                return result.Adapt<List<ProjectResponse>>();

            }
            catch (EntityNotFoundException)
            {
                return null;
            }

        }
    }
}
