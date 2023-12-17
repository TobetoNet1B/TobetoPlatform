using Core.Application.Responses;

namespace Application.Features.ModuleSets.Commands.Delete;

public class DeletedModuleSetResponse : IResponse
{
    public Guid Id { get; set; }
}