using Core.Persistence.Repositories;

namespace Domain.Entities;
public class StudentExam: Entity<Guid>
{
    public Guid StudentId { get; set; }
    public virtual Student Student { get; set; } = null!;
    public Guid ExamId { get; set; }
    public virtual Exam Exam { get; set; } = null!;
}
