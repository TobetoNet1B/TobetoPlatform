using Core.Application.Responses;

namespace Application.Features.Exams.Commands.Create;

public class CreatedExamResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public int? Time { get; set; }
    public int? QuestionCount { get; set; }
    public string? QuestionType { get; set; }
}