using Core.Application.Dtos;

namespace Application.Features.CategoryOfCourses.Queries.GetList;

public class GetListCategoryOfCourseListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool? IsActive { get; set; }
}