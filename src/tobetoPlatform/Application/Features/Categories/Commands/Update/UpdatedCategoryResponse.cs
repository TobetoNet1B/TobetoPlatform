using Core.Application.Responses;

namespace Application.Features.Categories.Commands.Update;

public class UpdatedCategoryResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool? IsActive { get; set; }
    public int? ParentId { get; set; }
    public int? OrderNo { get; set; }
}