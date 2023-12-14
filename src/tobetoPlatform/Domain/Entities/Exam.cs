using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Exam: Entity<Guid>
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public int? Time { get; set; }
    public int? QuestionCount { get; set; }
    public string? QuestionType { get; set; }
    public virtual ICollection<StudentExam> StudentExams { get; set; } = null!;

    public Exam()
    {
        
    }
    public Exam(Guid id,string name, string? description, int? time, int? questionCount, string? questionType) : base(id)
    {
        Name = name;
        Description = description;
        Time = time;
        QuestionCount = questionCount;
        QuestionType = questionType;
    }
}
