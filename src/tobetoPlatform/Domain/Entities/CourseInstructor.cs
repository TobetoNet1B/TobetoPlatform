using Core.Persistence.Repositories;

namespace Domain.Entities;
public class CourseInstructor : Entity<Guid>
{
    public Guid InstructorId { get; set; }
    public virtual Instructor Instructor { get; set; } = null!;
    public Guid CourseId { get; set; }
    public virtual Course Course { get; set; } = null!;
}
