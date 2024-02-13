using Core.Application.Dtos;

namespace Application.Features.ClassroomModules.Queries.GetList;

public class GetListClassroomModuleListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid ClassroomId { get; set; }
    public Guid ModuleSetId { get; set; }
    public DateTime? ClassroomStartDate { get; set; }
    public DateTime? ClassroomEndDate { get; set; }
}