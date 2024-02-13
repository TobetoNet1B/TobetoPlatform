using Core.Application.Responses;

namespace Application.Features.CategoryOfCourses.Commands.Create;

public class CreatedCategoryOfCourseResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool? IsActive { get; set; }
}