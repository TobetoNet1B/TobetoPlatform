using Core.Application.Responses;

namespace Application.Features.ModuleSetCategories.Commands.Delete;

public class DeletedModuleSetCategoryResponse : IResponse
{
    public Guid Id { get; set; }
}