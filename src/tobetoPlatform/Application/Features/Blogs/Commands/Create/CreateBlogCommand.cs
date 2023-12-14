using Application.Features.Blogs.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Blogs.Commands.Create;

public class CreateBlogCommand : IRequest<CreatedBlogResponse>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImgUrl { get; set; }

    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, CreatedBlogResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBlogRepository _blogRepository;
        private readonly BlogBusinessRules _blogBusinessRules;

        public CreateBlogCommandHandler(IMapper mapper, IBlogRepository blogRepository,
                                         BlogBusinessRules blogBusinessRules)
        {
            _mapper = mapper;
            _blogRepository = blogRepository;
            _blogBusinessRules = blogBusinessRules;
        }

        public async Task<CreatedBlogResponse> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            Blog blog = _mapper.Map<Blog>(request);

            await _blogRepository.AddAsync(blog);

            CreatedBlogResponse response = _mapper.Map<CreatedBlogResponse>(blog);
            return response;
        }
    }
}