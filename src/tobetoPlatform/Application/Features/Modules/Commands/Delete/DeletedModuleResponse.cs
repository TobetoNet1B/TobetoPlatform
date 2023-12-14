using Core.Application.Responses;

namespace Application.Features.Modules.Commands.Delete;

public class DeletedModuleResponse : IResponse
{
    public Guid Id { get; set; }
}