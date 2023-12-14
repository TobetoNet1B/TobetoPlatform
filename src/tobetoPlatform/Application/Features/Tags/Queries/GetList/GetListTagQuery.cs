using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Tags.Queries.GetList;

public class GetListTagQuery : IRequest<GetListResponse<GetListTagListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListTagQueryHandler : IRequestHandler<GetListTagQuery, GetListResponse<GetListTagListItemDto>>
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public GetListTagQueryHandler(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListTagListItemDto>> Handle(GetListTagQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Tag> tags = await _tagRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListTagListItemDto> response = _mapper.Map<GetListResponse<GetListTagListItemDto>>(tags);
            return response;
        }
    }
}