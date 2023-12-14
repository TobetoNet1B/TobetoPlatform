using Core.Application.Responses;

namespace Application.Features.Blogs.Commands.Delete;

public class DeletedBlogResponse : IResponse
{
    public Guid Id { get; set; }
}