using Core.Persistence.Repositories;

namespace Domain.Entities;
public class StudentExam: Entity<Guid>
{
    public Guid StudentId { get; set; }
    public Guid ExamId { get; set; }
    public bool IsAttended { get; set; }
    public int? CountOfTrue { get; set; }
    public int? CountOfFalse { get; set; }
    public int? CountOfEmpty { get; set; }
    public int? Score { get; set; }
    public virtual Student Student { get; set; } = null!;
    public virtual Exam Exam { get; set; } = null!;

    public StudentExam()
    {
        
    }
    public StudentExam(Guid id,Guid studentId, Guid examId, bool isAttended, int? countOfTrue, int? countOfFalse, int? countOfEmpty, int? score) : base(id)
    {
        StudentId = studentId;
        ExamId = examId;
        IsAttended = isAttended;
        CountOfTrue = countOfTrue;
        CountOfFalse = countOfFalse;
        CountOfEmpty = countOfEmpty;
        Score = score;
    }
}
