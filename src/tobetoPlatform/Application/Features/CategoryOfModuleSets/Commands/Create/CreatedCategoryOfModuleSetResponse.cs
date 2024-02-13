using Core.Application.Responses;

namespace Application.Features.CategoryOfModuleSets.Commands.Create;

public class CreatedCategoryOfModuleSetResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool? IsActive { get; set; }
}