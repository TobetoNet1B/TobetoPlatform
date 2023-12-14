using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Modules.Queries.GetList;

public class GetListModuleQuery : IRequest<GetListResponse<GetListModuleListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListModuleQueryHandler : IRequestHandler<GetListModuleQuery, GetListResponse<GetListModuleListItemDto>>
    {
        private readonly IModuleRepository _moduleRepository;
        private readonly IMapper _mapper;

        public GetListModuleQueryHandler(IModuleRepository moduleRepository, IMapper mapper)
        {
            _moduleRepository = moduleRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListModuleListItemDto>> Handle(GetListModuleQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Module> modules = await _moduleRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListModuleListItemDto> response = _mapper.Map<GetListResponse<GetListModuleListItemDto>>(modules);
            return response;
        }
    }
}