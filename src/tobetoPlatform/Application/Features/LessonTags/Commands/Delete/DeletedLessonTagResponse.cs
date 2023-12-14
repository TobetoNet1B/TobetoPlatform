using Core.Application.Responses;

namespace Application.Features.LessonTags.Commands.Delete;

public class DeletedLessonTagResponse : IResponse
{
    public Guid Id { get; set; }
}