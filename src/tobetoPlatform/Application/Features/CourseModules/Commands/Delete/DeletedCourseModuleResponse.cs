using Core.Application.Responses;

namespace Application.Features.CourseModules.Commands.Delete;

public class DeletedCourseModuleResponse : IResponse
{
    public Guid Id { get; set; }
}