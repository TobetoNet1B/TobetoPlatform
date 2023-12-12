using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Blogs.Queries.GetList;

public class GetListBlogQuery : IRequest<GetListResponse<GetListBlogListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListBlogQueryHandler : IRequestHandler<GetListBlogQuery, GetListResponse<GetListBlogListItemDto>>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public GetListBlogQueryHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListBlogListItemDto>> Handle(GetListBlogQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Blog> blogs = await _blogRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListBlogListItemDto> response = _mapper.Map<GetListResponse<GetListBlogListItemDto>>(blogs);
            return response;
        }
    }
}