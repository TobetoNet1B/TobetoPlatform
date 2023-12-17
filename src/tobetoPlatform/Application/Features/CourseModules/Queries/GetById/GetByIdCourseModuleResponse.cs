using Core.Application.Responses;

namespace Application.Features.CourseModules.Queries.GetById;

public class GetByIdCourseModuleResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public Guid ModuleSetId { get; set; }
}