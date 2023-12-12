using Core.Application.Responses;

namespace Application.Features.Exams.Commands.Update;

public class UpdatedExamResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public int? Time { get; set; }
    public int? QuestionNumber { get; set; }
    public string? QuestionType { get; set; }
}