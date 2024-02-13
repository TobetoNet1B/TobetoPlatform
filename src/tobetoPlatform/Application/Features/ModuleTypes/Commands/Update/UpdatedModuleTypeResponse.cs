using Core.Application.Responses;

namespace Application.Features.ModuleTypes.Commands.Update;

public class UpdatedModuleTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}