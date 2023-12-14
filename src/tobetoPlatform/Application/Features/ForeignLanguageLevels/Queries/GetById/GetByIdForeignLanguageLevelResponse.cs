using Core.Application.Responses;

namespace Application.Features.ForeignLanguageLevels.Queries.GetById;

public class GetByIdForeignLanguageLevelResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}