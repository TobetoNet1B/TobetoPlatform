using Core.Application.Responses;

namespace Application.Features.CourseCategories.Commands.Update;

public class UpdatedCourseCategoryResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public Guid CategoryOfCourseId { get; set; }
}