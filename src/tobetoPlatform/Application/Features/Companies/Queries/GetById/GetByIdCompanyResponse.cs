using Core.Application.Responses;

namespace Application.Features.Companies.Queries.GetById;

public class GetByIdCompanyResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}