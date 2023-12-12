using Core.Application.Dtos;

namespace Application.Features.CourseCategories.Queries.GetList;

public class GetListCourseCategoryListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public Guid CategoryId { get; set; }
}