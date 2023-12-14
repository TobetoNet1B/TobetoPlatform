using Core.Application.Responses;

namespace Application.Features.Courses.Queries.GetById;

public class GetByIdCourseResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? CourseTitle { get; set; }
    public string? Description { get; set; }
    public int? CourseLevel { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int? EstimatedTime { get; set; }
    public string ActivityStatus { get; set; }
}