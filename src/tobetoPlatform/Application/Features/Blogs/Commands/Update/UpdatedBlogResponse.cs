using Core.Application.Responses;

namespace Application.Features.Blogs.Commands.Update;

public class UpdatedBlogResponse : IResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImgUrl { get; set; }
}