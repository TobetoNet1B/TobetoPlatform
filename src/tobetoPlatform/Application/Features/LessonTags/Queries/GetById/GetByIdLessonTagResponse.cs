using Core.Application.Responses;

namespace Application.Features.LessonTags.Queries.GetById;

public class GetByIdLessonTagResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid LessonId { get; set; }
    public Guid TagId { get; set; }
}