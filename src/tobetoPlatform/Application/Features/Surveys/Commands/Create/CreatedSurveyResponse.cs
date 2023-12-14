using Core.Application.Responses;

namespace Application.Features.Surveys.Commands.Create;

public class CreatedSurveyResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string SurveyUrl { get; set; }
    public Guid StudentId { get; set; }
}