using Core.Application.Responses;

namespace Application.Features.Exams.Queries.GetById;

public class GetByIdExamResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public int? Time { get; set; }
    public int? QuestionCount { get; set; }
    public string? QuestionType { get; set; }
}