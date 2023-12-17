using Core.Application.Dtos;

namespace Application.Features.CourseModules.Queries.GetList;

public class GetListCourseModuleListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public Guid ModuleSetId { get; set; }
}