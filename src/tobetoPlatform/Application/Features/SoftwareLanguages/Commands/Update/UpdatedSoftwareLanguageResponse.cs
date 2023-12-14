using Core.Application.Responses;

namespace Application.Features.SoftwareLanguages.Commands.Update;

public class UpdatedSoftwareLanguageResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}