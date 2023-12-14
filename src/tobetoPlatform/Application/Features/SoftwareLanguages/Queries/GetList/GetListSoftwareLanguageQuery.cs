using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SoftwareLanguages.Queries.GetList;

public class GetListSoftwareLanguageQuery : IRequest<GetListResponse<GetListSoftwareLanguageListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListSoftwareLanguageQueryHandler : IRequestHandler<GetListSoftwareLanguageQuery, GetListResponse<GetListSoftwareLanguageListItemDto>>
    {
        private readonly ISoftwareLanguageRepository _softwareLanguageRepository;
        private readonly IMapper _mapper;

        public GetListSoftwareLanguageQueryHandler(ISoftwareLanguageRepository softwareLanguageRepository, IMapper mapper)
        {
            _softwareLanguageRepository = softwareLanguageRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSoftwareLanguageListItemDto>> Handle(GetListSoftwareLanguageQuery request, CancellationToken cancellationToken)
        {
            IPaginate<SoftwareLanguage> softwareLanguages = await _softwareLanguageRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSoftwareLanguageListItemDto> response = _mapper.Map<GetListResponse<GetListSoftwareLanguageListItemDto>>(softwareLanguages);
            return response;
        }
    }
}