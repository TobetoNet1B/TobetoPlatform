using Application.Features.Blogs.Constants;
using Application.Features.Blogs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Blogs.Commands.Delete;

public class DeleteBlogCommand : IRequest<DeletedBlogResponse>
{
    public Guid Id { get; set; }

    public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, DeletedBlogResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBlogRepository _blogRepository;
        private readonly BlogBusinessRules _blogBusinessRules;

        public DeleteBlogCommandHandler(IMapper mapper, IBlogRepository blogRepository,
                                         BlogBusinessRules blogBusinessRules)
        {
            _mapper = mapper;
            _blogRepository = blogRepository;
            _blogBusinessRules = blogBusinessRules;
        }

        public async Task<DeletedBlogResponse> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            Blog? blog = await _blogRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
            await _blogBusinessRules.BlogShouldExistWhenSelected(blog);

            await _blogRepository.DeleteAsync(blog!);

            DeletedBlogResponse response = _mapper.Map<DeletedBlogResponse>(blog);
            return response;
        }
    }
}