namespace TimeTracker.Shared.Models.Project
{

    public record struct ProjectCreatedRequest(  
        string Name,
        string? Description,
        DateTime? StartDate,
        DateTime? EndDate);

}
