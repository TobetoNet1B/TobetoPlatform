using Core.Application.Responses;

namespace Application.Features.CategoryOfCourses.Commands.Update;

public class UpdatedCategoryOfCourseResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool? IsActive { get; set; }
}