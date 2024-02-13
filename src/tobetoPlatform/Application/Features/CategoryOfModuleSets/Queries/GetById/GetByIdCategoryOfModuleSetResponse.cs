using Core.Application.Responses;

namespace Application.Features.CategoryOfModuleSets.Queries.GetById;

public class GetByIdCategoryOfModuleSetResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool? IsActive { get; set; }
}