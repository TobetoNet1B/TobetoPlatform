using Core.Application.Dtos;

namespace Application.Features.Exams.Queries.GetList;

public class GetListExamListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public int? Time { get; set; }
    public int? QuestionNumber { get; set; }
    public string? QuestionType { get; set; }
}