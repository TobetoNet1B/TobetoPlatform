using Core.Application.Responses;

namespace Application.Features.LessonTags.Commands.Create;

public class CreatedLessonTagResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid LessonId { get; set; }
    public Guid TagId { get; set; }
}