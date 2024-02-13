using Core.Application.Dtos;

namespace Application.Features.Lessons.Queries.GetList;

public class GetListLessonListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string LessonUrl { get; set; }
    public string? ImgUrl { get; set; }
    public string? LessonType { get; set; }
    public int? Duration { get; set; }
    public Guid? CourseId { get; set; }
    public Guid? SpeakerId { get; set; }
}