using TimeTracker.Shared.Models.Project;


namespace TimeTracker.API.Services
{
    public interface IProjectServices
    {
        Task<List<ProjectResponse>> GetAllProjects();

        Task<ProjectResponse?> GetProjectById(int id);

        Task<List<ProjectResponse>> CreateProject(ProjectCreatedRequest project);

        Task<List<ProjectResponse>?> UpdateProject(int id, ProjectUpdateRequest project);

        Task<List<ProjectResponse>?> DeleteProject(int id);
    }
}
