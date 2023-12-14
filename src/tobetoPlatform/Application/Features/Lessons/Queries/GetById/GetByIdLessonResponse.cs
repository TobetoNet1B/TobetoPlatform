using Core.Application.Responses;

namespace Application.Features.Lessons.Queries.GetById;

public class GetByIdLessonResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string LessonUrl { get; set; }
    public string? ImgUrl { get; set; }
    public string LessonType { get; set; }
    public int? Duration { get; set; }
    public Guid CourseId { get; set; }
}