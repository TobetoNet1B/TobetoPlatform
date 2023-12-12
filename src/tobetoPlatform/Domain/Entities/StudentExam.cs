using Core.Persistence.Repositories;

namespace Domain.Entities;
public class StudentExam: Entity<Guid>
{
    public Guid StudentId { get; set; }
    public Student Student { get; set; }
    public Guid ExamId { get; set; }
    public Exam Exam { get; set; }
}
