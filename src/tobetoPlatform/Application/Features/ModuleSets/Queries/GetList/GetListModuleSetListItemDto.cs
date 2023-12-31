using Core.Application.Dtos;

namespace Application.Features.ModuleSets.Queries.GetList;

public class GetListModuleSetListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImgUrl { get; set; }
    public Guid CategoryId { get; set; }
    public Guid SoftwareLanguageId { get; set; }
    public Guid CompanyId { get; set; }
}