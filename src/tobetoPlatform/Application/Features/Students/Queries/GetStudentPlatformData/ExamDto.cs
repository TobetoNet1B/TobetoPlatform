

namespace Application.Features.Students.Queries.GetStudentPlatformData;
public class ExamDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public int? Time { get; set; }
    public int? QuestionCount { get; set; }
    public string? QuestionType { get; set; }
}
