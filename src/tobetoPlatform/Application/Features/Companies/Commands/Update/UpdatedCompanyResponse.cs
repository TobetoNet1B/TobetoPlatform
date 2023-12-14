using Core.Application.Responses;

namespace Application.Features.Companies.Commands.Update;

public class UpdatedCompanyResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}