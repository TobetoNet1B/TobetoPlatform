using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Instructor: Entity<Guid>
{
    public string Name { get; set; }
    public virtual ICollection<CourseInstructor> CourseInstructors { get; set; } = null!;

}
