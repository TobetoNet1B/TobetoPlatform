using Core.Application.Responses;

namespace Application.Features.Appeals.Queries.GetById;

public class GetByIdAppealResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}