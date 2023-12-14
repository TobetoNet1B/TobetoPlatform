using Core.Application.Responses;

namespace Application.Features.SoftwareLanguages.Queries.GetById;

public class GetByIdSoftwareLanguageResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}