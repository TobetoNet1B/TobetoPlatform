using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.ModuleSets.Queries.GetList;

public class GetListModuleSetQuery : IRequest<GetListResponse<GetListModuleSetListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListModuleSetQueryHandler : IRequestHandler<GetListModuleSetQuery, GetListResponse<GetListModuleSetListItemDto>>
    {
        private readonly IModuleSetRepository _moduleSetRepository;
        private readonly IMapper _mapper;

        public GetListModuleSetQueryHandler(IModuleSetRepository moduleSetRepository, IMapper mapper)
        {
            _moduleSetRepository = moduleSetRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListModuleSetListItemDto>> Handle(GetListModuleSetQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ModuleSet> moduleSets = await _moduleSetRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListModuleSetListItemDto> response = _mapper.Map<GetListResponse<GetListModuleSetListItemDto>>(moduleSets);
            return response;
        }
    }
}