using Core.Application.Dtos;

namespace Application.Features.SoftwareLanguages.Queries.GetList;

public class GetListSoftwareLanguageListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}