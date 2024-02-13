using Core.Application.Dtos;

namespace Application.Features.ModuleTypes.Queries.GetList;

public class GetListModuleTypeListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}