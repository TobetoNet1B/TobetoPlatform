using Core.Persistence.Repositories;

namespace Domain.Entities;
public class CourseInstructor : Entity<Guid>
{
    public Guid InstructorId { get; set; }
    public virtual Instructor Instructor { get; set; } = null!;
    public Guid CourseId { get; set; }
    public virtual Course Course { get; set; } = null!;
    public CourseInstructor()
    {
        
    }

    public CourseInstructor(Guid id,Guid instructorId, Instructor instructor, Guid courseId, Course course) : base(id)
    {
        InstructorId = instructorId;
        Instructor = instructor;
        CourseId = courseId;
        Course = course;
    }
}
