using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Exam: Entity<Guid>
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public int? Time { get; set; }
    public int? QuestionNumber { get; set; }
    public string? QuestionType { get; set; }
    public List<StudentExam> StudentExams { get; set; }
}
