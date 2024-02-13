using Core.Application.Responses;

namespace Application.Features.ModuleSetCategories.Queries.GetById;

public class GetByIdModuleSetCategoryResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid ModuleSetId { get; set; }
    public Guid CategoryOfModuleSetId { get; set; }
}