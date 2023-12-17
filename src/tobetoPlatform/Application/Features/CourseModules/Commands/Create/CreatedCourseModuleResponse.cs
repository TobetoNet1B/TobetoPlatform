using Core.Application.Responses;

namespace Application.Features.CourseModules.Commands.Create;

public class CreatedCourseModuleResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public Guid ModuleSetId { get; set; }
}