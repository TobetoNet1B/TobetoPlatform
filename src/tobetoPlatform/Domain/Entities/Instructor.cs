using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Instructor: Entity<Guid>
{
    public string Name { get; set; }
    public List<CourseInstructor> CourseInstructors { get; set; }

}
