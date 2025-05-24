

namespace TimeTracker.Shared.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime DateCreate { get; set; } = DateTime.Now;

        public DateTime? DateUpdated { get; set; }
    }
}
