using Core.Persistence.Repositories;

namespace Domain.Entities;
public class CourseInstructor : Entity<Guid>
{
    public Guid InstructorId { get; set; }
    public Guid CourseId { get; set; }
    public virtual Instructor Instructor { get; set; } = null!;
    public virtual Course Course { get; set; } = null!;

    public CourseInstructor()
    {
        
    }
    public CourseInstructor(Guid id,Guid instructorId, Guid courseId) : base(id)
    {
        InstructorId = instructorId;
        CourseId = courseId;
    }
}
