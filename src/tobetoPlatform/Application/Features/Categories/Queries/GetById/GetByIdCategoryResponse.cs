using Core.Application.Responses;

namespace Application.Features.Categories.Queries.GetById;

public class GetByIdCategoryResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool? IsActive { get; set; }
    public int? ParentId { get; set; }
    public int? OrderNo { get; set; }
}