using Core.Application.Dtos;

namespace Application.Features.CategoryOfModuleSets.Queries.GetList;

public class GetListCategoryOfModuleSetListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool? IsActive { get; set; }
}