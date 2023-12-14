using Core.Application.Responses;

namespace Application.Features.SoftwareLanguages.Commands.Create;

public class CreatedSoftwareLanguageResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}