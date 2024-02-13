using Core.Application.Responses;

namespace Application.Features.CategoryOfCourses.Commands.Delete;

public class DeletedCategoryOfCourseResponse : IResponse
{
    public Guid Id { get; set; }
}