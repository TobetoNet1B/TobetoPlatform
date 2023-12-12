using Core.Persistence.Repositories;

namespace Domain.Entities;
public class CourseStudent: Entity<Guid>
{
    public Guid CourseId { get; set; }
    public virtual Course Course { get; set; } = null!;
    public Guid StudentId { get; set; }
    public virtual Student Student { get; set; } = null!;
}
