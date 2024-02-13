using Core.Application.Responses;

namespace Application.Features.CategoryOfCourses.Queries.GetById;

public class GetByIdCategoryOfCourseResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool? IsActive { get; set; }
}