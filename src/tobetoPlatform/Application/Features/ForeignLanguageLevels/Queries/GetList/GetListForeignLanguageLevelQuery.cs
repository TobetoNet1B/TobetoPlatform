using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.ForeignLanguageLevels.Queries.GetList;

public class GetListForeignLanguageLevelQuery : IRequest<GetListResponse<GetListForeignLanguageLevelListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListForeignLanguageLevelQueryHandler : IRequestHandler<GetListForeignLanguageLevelQuery, GetListResponse<GetListForeignLanguageLevelListItemDto>>
    {
        private readonly IForeignLanguageLevelRepository _foreignLanguageLevelRepository;
        private readonly IMapper _mapper;

        public GetListForeignLanguageLevelQueryHandler(IForeignLanguageLevelRepository foreignLanguageLevelRepository, IMapper mapper)
        {
            _foreignLanguageLevelRepository = foreignLanguageLevelRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListForeignLanguageLevelListItemDto>> Handle(GetListForeignLanguageLevelQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ForeignLanguageLevel> foreignLanguageLevels = await _foreignLanguageLevelRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListForeignLanguageLevelListItemDto> response = _mapper.Map<GetListResponse<GetListForeignLanguageLevelListItemDto>>(foreignLanguageLevels);
            return response;
        }
    }
}