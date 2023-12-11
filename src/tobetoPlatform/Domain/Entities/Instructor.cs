using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Instructor: Entity<Guid>
{
    public string Name { get; set; }
    public Guid CourseInstructorId { get; set; }
    public CourseInstructor CourseInstructors { get; set; }

}
