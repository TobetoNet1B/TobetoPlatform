using Core.Application.Responses;

namespace Application.Features.CourseModules.Commands.Update;

public class UpdatedCourseModuleResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public Guid ModuleSetId { get; set; }
}