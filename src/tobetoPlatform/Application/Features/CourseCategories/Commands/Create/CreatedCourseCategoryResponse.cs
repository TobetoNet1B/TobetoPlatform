using Core.Application.Responses;

namespace Application.Features.CourseCategories.Commands.Create;

public class CreatedCourseCategoryResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public Guid CategoryId { get; set; }
}