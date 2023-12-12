using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Appeals.Queries.GetList;

public class GetListAppealQuery : IRequest<GetListResponse<GetListAppealListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListAppealQueryHandler : IRequestHandler<GetListAppealQuery, GetListResponse<GetListAppealListItemDto>>
    {
        private readonly IAppealRepository _appealRepository;
        private readonly IMapper _mapper;

        public GetListAppealQueryHandler(IAppealRepository appealRepository, IMapper mapper)
        {
            _appealRepository = appealRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAppealListItemDto>> Handle(GetListAppealQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Appeal> appeals = await _appealRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAppealListItemDto> response = _mapper.Map<GetListResponse<GetListAppealListItemDto>>(appeals);
            return response;
        }
    }
}