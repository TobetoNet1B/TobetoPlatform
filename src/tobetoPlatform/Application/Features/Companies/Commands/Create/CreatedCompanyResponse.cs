using Core.Application.Responses;

namespace Application.Features.Companies.Commands.Create;

public class CreatedCompanyResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}