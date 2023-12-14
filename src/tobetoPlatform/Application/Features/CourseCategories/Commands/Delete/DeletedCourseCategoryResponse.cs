using Core.Application.Responses;

namespace Application.Features.CourseCategories.Commands.Delete;

public class DeletedCourseCategoryResponse : IResponse
{
    public Guid Id { get; set; }
}