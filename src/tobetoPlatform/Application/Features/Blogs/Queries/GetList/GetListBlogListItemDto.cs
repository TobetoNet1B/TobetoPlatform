using Core.Application.Dtos;

namespace Application.Features.Blogs.Queries.GetList;

public class GetListBlogListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImgUrl { get; set; }
}