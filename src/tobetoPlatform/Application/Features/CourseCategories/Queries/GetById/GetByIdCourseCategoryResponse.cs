using Core.Application.Responses;

namespace Application.Features.CourseCategories.Queries.GetById;

public class GetByIdCourseCategoryResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public Guid CategoryId { get; set; }
}