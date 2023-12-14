using Core.Application.Responses;

namespace Application.Features.ForeignLanguages.Queries.GetById;

public class GetByIdForeignLanguageResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid ForeignLanguageLevelId { get; set; }
    public Guid StudentId { get; set; }
}