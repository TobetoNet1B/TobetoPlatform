using Core.Application.Responses;

namespace Application.Features.ModuleTypes.Commands.Delete;

public class DeletedModuleTypeResponse : IResponse
{
    public Guid Id { get; set; }
}