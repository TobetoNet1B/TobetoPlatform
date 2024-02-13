using Core.Application.Responses;

namespace Application.Features.ModuleSetCategories.Commands.Update;

public class UpdatedModuleSetCategoryResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid ModuleSetId { get; set; }
    public Guid CategoryOfModuleSetId { get; set; }
}