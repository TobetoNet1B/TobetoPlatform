using Core.Application.Dtos;

namespace Application.Features.LessonTags.Queries.GetList;

public class GetListLessonTagListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid LessonId { get; set; }
    public Guid TagId { get; set; }
}