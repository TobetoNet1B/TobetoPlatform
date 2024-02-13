using Core.Application.Responses;

namespace Application.Features.CategoryOfModuleSets.Commands.Update;

public class UpdatedCategoryOfModuleSetResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool? IsActive { get; set; }
}