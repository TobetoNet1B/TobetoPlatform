using Core.Persistence.Repositories;

namespace Domain.Entities;
public class StudentExam: Entity<Guid>
{
    public Guid StudentId { get; set; }
    public virtual Student Student { get; set; } = null!;
    public Guid ExamId { get; set; }
    public virtual Exam Exam { get; set; } = null!; 
    public bool IsAttended { get; set; }
    public int? CountOfTrue { get; set; }
    public int? CountOfFalse { get; set; }
    public int? CountOfEmpty { get; set; }
    public int? Score { get; set; }
    public StudentExam()
    {
        
    }

    public StudentExam(Guid id,Guid studentId, Student student, Guid examId, Exam exam, bool isAttended, int? countOfTrue, int? countOfFalse, int? countOfEmpty, int? score) : base(id)
    {
        StudentId = studentId;
        Student = student;
        ExamId = examId;
        Exam = exam;
        IsAttended = isAttended;
        CountOfTrue = countOfTrue;
        CountOfFalse = countOfFalse;
        CountOfEmpty = countOfEmpty;
        Score = score;
    }
}
