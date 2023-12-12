using Core.Persistence.Repositories;

namespace Domain.Entities;
public class CourseCategory: Entity<Guid>
{
    public Guid CourseId { get; set; }
    public Course Course { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
}
