using Core.Application.Responses;

namespace Application.Features.ModuleTypes.Queries.GetById;

public class GetByIdModuleTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}