using Core.Application.Dtos;

namespace Application.Features.ForeignLanguageLevels.Queries.GetList;

public class GetListForeignLanguageLevelListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}