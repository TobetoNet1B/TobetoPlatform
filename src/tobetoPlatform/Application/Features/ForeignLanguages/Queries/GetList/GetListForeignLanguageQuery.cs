using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.ForeignLanguages.Queries.GetList;

public class GetListForeignLanguageQuery : IRequest<GetListResponse<GetListForeignLanguageListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListForeignLanguageQueryHandler : IRequestHandler<GetListForeignLanguageQuery, GetListResponse<GetListForeignLanguageListItemDto>>
    {
        private readonly IForeignLanguageRepository _foreignLanguageRepository;
        private readonly IMapper _mapper;

        public GetListForeignLanguageQueryHandler(IForeignLanguageRepository foreignLanguageRepository, IMapper mapper)
        {
            _foreignLanguageRepository = foreignLanguageRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListForeignLanguageListItemDto>> Handle(GetListForeignLanguageQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ForeignLanguage> foreignLanguages = await _foreignLanguageRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListForeignLanguageListItemDto> response = _mapper.Map<GetListResponse<GetListForeignLanguageListItemDto>>(foreignLanguages);
            return response;
        }
    }
}