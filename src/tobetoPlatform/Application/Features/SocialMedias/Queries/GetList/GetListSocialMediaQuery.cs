using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SocialMedias.Queries.GetList;

public class GetListSocialMediaQuery : IRequest<GetListResponse<GetListSocialMediaListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListSocialMediaQueryHandler : IRequestHandler<GetListSocialMediaQuery, GetListResponse<GetListSocialMediaListItemDto>>
    {
        private readonly ISocialMediaRepository _socialMediaRepository;
        private readonly IMapper _mapper;

        public GetListSocialMediaQueryHandler(ISocialMediaRepository socialMediaRepository, IMapper mapper)
        {
            _socialMediaRepository = socialMediaRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSocialMediaListItemDto>> Handle(GetListSocialMediaQuery request, CancellationToken cancellationToken)
        {
            IPaginate<SocialMedia> socialMedias = await _socialMediaRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSocialMediaListItemDto> response = _mapper.Map<GetListResponse<GetListSocialMediaListItemDto>>(socialMedias);
            return response;
        }
    }
}