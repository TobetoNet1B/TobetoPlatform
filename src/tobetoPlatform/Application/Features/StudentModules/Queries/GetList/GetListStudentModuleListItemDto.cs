using Core.Application.Dtos;

namespace Application.Features.StudentModules.Queries.GetList;

public class GetListStudentModuleListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid ModuleId { get; set; }
    public int? TimeSpent { get; set; }
}