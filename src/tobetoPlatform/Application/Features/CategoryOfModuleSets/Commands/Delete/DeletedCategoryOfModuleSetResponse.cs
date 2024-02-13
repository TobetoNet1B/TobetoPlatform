using Core.Application.Responses;

namespace Application.Features.CategoryOfModuleSets.Commands.Delete;

public class DeletedCategoryOfModuleSetResponse : IResponse
{
    public Guid Id { get; set; }
}