using Core.Persistence.Repositories;

namespace Domain.Entities;
public class StudentClassroom:Entity<Guid>
{
    public Guid StudentId { get; set; }
    public Guid ClassroomId { get; set; }
    public virtual Student Student { get; set; } = null!;
    public virtual Classroom Classroom { get; set; } = null!;

    public StudentClassroom()
    {
    }

    public StudentClassroom(Guid id, Guid studentId, Guid classroomId):base(id)
    {
        StudentId = studentId;
        ClassroomId = classroomId;
    }
}
