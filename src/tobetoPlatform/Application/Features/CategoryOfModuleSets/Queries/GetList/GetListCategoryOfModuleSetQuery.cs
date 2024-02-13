using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.CategoryOfModuleSets.Queries.GetList;

public class GetListCategoryOfModuleSetQuery : IRequest<GetListResponse<GetListCategoryOfModuleSetListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListCategoryOfModuleSetQueryHandler : IRequestHandler<GetListCategoryOfModuleSetQuery, GetListResponse<GetListCategoryOfModuleSetListItemDto>>
    {
        private readonly ICategoryOfModuleSetRepository _categoryOfModuleSetRepository;
        private readonly IMapper _mapper;

        public GetListCategoryOfModuleSetQueryHandler(ICategoryOfModuleSetRepository categoryOfModuleSetRepository, IMapper mapper)
        {
            _categoryOfModuleSetRepository = categoryOfModuleSetRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCategoryOfModuleSetListItemDto>> Handle(GetListCategoryOfModuleSetQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CategoryOfModuleSet> categoryOfModuleSets = await _categoryOfModuleSetRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCategoryOfModuleSetListItemDto> response = _mapper.Map<GetListResponse<GetListCategoryOfModuleSetListItemDto>>(categoryOfModuleSets);
            return response;
        }
    }
}