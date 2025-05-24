namespace TimeTracker.Shared.Entities
{
    public class TimeEntry : BaseEntity
    {
        public required string Project { get; set; }

        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }
    }
}
