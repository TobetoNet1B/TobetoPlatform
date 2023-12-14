using Core.Application.Responses;

namespace Application.Features.Companies.Commands.Delete;

public class DeletedCompanyResponse : IResponse
{
    public Guid Id { get; set; }
}