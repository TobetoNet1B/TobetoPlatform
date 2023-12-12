using Core.Persistence.Repositories;

namespace Domain.Entities;
public class CourseStudent: Entity<Guid>
{
    public Guid CourseId { get; set; }
    public Course Course { get; set; }
    public Guid StudentId { get; set; }
    public Student Student { get; set; }
}
