using Core.Application.Responses;

namespace Application.Features.Courses.Commands.Create;

public class CreatedCourseResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? CourseTitle { get; set; }
    public string? Description { get; set; }
    public int? CourseLevel { get; set; }
    public string? ImgUrl { get; set; }
    public string SoftwareLanguage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int? EstimatedTime { get; set; }
    public int? TimeSpent { get; set; }
    public int? Duration { get; set; }
    public string ActivityStatus { get; set; }
}