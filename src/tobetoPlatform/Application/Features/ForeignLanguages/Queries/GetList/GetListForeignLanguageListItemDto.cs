using Core.Application.Dtos;

namespace Application.Features.ForeignLanguages.Queries.GetList;

public class GetListForeignLanguageListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid ForeignLanguageLevelId { get; set; }
    public Guid StudentId { get; set; }
}