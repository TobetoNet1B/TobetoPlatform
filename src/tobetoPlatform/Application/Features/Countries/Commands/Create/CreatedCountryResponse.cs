using Core.Application.Responses;

namespace Application.Features.Countries.Commands.Create;

public class CreatedCountryResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}