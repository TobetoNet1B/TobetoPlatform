using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Addresses.Queries.GetList;

public class GetListAddressQuery : IRequest<GetListResponse<GetListAddressListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListAddressQueryHandler : IRequestHandler<GetListAddressQuery, GetListResponse<GetListAddressListItemDto>>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public GetListAddressQueryHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAddressListItemDto>> Handle(GetListAddressQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Address> addresses = await _addressRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAddressListItemDto> response = _mapper.Map<GetListResponse<GetListAddressListItemDto>>(addresses);
            return response;
        }
    }
}