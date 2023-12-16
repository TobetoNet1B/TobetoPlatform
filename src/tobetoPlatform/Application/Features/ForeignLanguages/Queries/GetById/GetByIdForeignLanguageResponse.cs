using Core.Application.Responses;

namespace Application.Features.ForeignLanguages.Queries.GetById;

public class GetByIdForeignLanguageResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}