using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.ModuleTypes.Queries.GetList;

public class GetListModuleTypeQuery : IRequest<GetListResponse<GetListModuleTypeListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListModuleTypeQueryHandler : IRequestHandler<GetListModuleTypeQuery, GetListResponse<GetListModuleTypeListItemDto>>
    {
        private readonly IModuleTypeRepository _moduleTypeRepository;
        private readonly IMapper _mapper;

        public GetListModuleTypeQueryHandler(IModuleTypeRepository moduleTypeRepository, IMapper mapper)
        {
            _moduleTypeRepository = moduleTypeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListModuleTypeListItemDto>> Handle(GetListModuleTypeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ModuleType> moduleTypes = await _moduleTypeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListModuleTypeListItemDto> response = _mapper.Map<GetListResponse<GetListModuleTypeListItemDto>>(moduleTypes);
            return response;
        }
    }
}