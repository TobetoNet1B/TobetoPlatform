using Core.Application.Responses;

namespace Application.Features.ModuleTypes.Commands.Create;

public class CreatedModuleTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}