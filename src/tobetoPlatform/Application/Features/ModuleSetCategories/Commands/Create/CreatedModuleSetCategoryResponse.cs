using Core.Application.Responses;

namespace Application.Features.ModuleSetCategories.Commands.Create;

public class CreatedModuleSetCategoryResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid ModuleSetId { get; set; }
    public Guid CategoryOfModuleSetId { get; set; }
}