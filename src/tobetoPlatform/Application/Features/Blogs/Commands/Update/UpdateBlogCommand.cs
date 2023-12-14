using Application.Features.Blogs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Blogs.Commands.Update;

public class UpdateBlogCommand : IRequest<UpdatedBlogResponse>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImgUrl { get; set; }

    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, UpdatedBlogResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBlogRepository _blogRepository;
        private readonly BlogBusinessRules _blogBusinessRules;

        public UpdateBlogCommandHandler(IMapper mapper, IBlogRepository blogRepository,
                                         BlogBusinessRules blogBusinessRules)
        {
            _mapper = mapper;
            _blogRepository = blogRepository;
            _blogBusinessRules = blogBusinessRules;
        }

        public async Task<UpdatedBlogResponse> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            Blog? blog = await _blogRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
            await _blogBusinessRules.BlogShouldExistWhenSelected(blog);
            blog = _mapper.Map(request, blog);

            await _blogRepository.UpdateAsync(blog!);

            UpdatedBlogResponse response = _mapper.Map<UpdatedBlogResponse>(blog);
            return response;
        }
    }
}