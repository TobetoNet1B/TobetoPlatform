using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.TobetoContacts.Queries.GetList;

public class GetListTobetoContactQuery : IRequest<GetListResponse<GetListTobetoContactListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListTobetoContactQueryHandler : IRequestHandler<GetListTobetoContactQuery, GetListResponse<GetListTobetoContactListItemDto>>
    {
        private readonly ITobetoContactRepository _tobetoContactRepository;
        private readonly IMapper _mapper;

        public GetListTobetoContactQueryHandler(ITobetoContactRepository tobetoContactRepository, IMapper mapper)
        {
            _tobetoContactRepository = tobetoContactRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListTobetoContactListItemDto>> Handle(GetListTobetoContactQuery request, CancellationToken cancellationToken)
        {
            IPaginate<TobetoContact> tobetoContacts = await _tobetoContactRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListTobetoContactListItemDto> response = _mapper.Map<GetListResponse<GetListTobetoContactListItemDto>>(tobetoContacts);
            return response;
        }
    }
}