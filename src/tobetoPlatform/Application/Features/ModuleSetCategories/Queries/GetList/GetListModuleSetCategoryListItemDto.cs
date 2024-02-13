using Core.Application.Dtos;

namespace Application.Features.ModuleSetCategories.Queries.GetList;

public class GetListModuleSetCategoryListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid ModuleSetId { get; set; }
    public Guid CategoryOfModuleSetId { get; set; }
}