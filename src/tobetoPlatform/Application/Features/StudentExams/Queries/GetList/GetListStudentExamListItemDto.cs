using Core.Application.Dtos;

namespace Application.Features.StudentExams.Queries.GetList;

public class GetListStudentExamListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid ExamId { get; set; }
    public bool IsAttended { get; set; }
    public int? CountOfTrue { get; set; }
    public int? CountOfFalse { get; set; }
    public int? CountOfEmpty { get; set; }
    public int? Score { get; set; }
}