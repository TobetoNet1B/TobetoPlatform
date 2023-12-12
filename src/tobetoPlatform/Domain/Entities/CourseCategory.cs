using Core.Persistence.Repositories;

namespace Domain.Entities;
public class CourseCategory: Entity<Guid>
{
    public Guid CourseId { get; set; }
    public virtual Course Course { get; set; } = null!;
    public Guid CategoryId { get; set; }
    public virtual Category Category { get; set; } = null!;
}
