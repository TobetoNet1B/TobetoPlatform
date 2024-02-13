using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.ModuleSetCategories.Queries.GetList;

public class GetListModuleSetCategoryQuery : IRequest<GetListResponse<GetListModuleSetCategoryListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListModuleSetCategoryQueryHandler : IRequestHandler<GetListModuleSetCategoryQuery, GetListResponse<GetListModuleSetCategoryListItemDto>>
    {
        private readonly IModuleSetCategoryRepository _moduleSetCategoryRepository;
        private readonly IMapper _mapper;

        public GetListModuleSetCategoryQueryHandler(IModuleSetCategoryRepository moduleSetCategoryRepository, IMapper mapper)
        {
            _moduleSetCategoryRepository = moduleSetCategoryRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListModuleSetCategoryListItemDto>> Handle(GetListModuleSetCategoryQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ModuleSetCategory> moduleSetCategories = await _moduleSetCategoryRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListModuleSetCategoryListItemDto> response = _mapper.Map<GetListResponse<GetListModuleSetCategoryListItemDto>>(moduleSetCategories);
            return response;
        }
    }
}