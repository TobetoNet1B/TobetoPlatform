using Core.Application.Responses;

namespace Application.Features.LessonTags.Commands.Update;

public class UpdatedLessonTagResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid LessonId { get; set; }
    public Guid TagId { get; set; }
}