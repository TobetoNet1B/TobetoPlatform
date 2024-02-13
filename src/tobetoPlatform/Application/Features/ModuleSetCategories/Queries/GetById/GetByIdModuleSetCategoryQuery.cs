using Application.Features.ModuleSetCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ModuleSetCategories.Queries.GetById;

public class GetByIdModuleSetCategoryQuery : IRequest<GetByIdModuleSetCategoryResponse>
{
    public Guid Id { get; set; }

    public class GetByIdModuleSetCategoryQueryHandler : IRequestHandler<GetByIdModuleSetCategoryQuery, GetByIdModuleSetCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IModuleSetCategoryRepository _moduleSetCategoryRepository;
        private readonly ModuleSetCategoryBusinessRules _moduleSetCategoryBusinessRules;

        public GetByIdModuleSetCategoryQueryHandler(IMapper mapper, IModuleSetCategoryRepository moduleSetCategoryRepository, ModuleSetCategoryBusinessRules moduleSetCategoryBusinessRules)
        {
            _mapper = mapper;
            _moduleSetCategoryRepository = moduleSetCategoryRepository;
            _moduleSetCategoryBusinessRules = moduleSetCategoryBusinessRules;
        }

        public async Task<GetByIdModuleSetCategoryResponse> Handle(GetByIdModuleSetCategoryQuery request, CancellationToken cancellationToken)
        {
            ModuleSetCategory? moduleSetCategory = await _moduleSetCategoryRepository.GetAsync(predicate: msc => msc.Id == request.Id, cancellationToken: cancellationToken);
            await _moduleSetCategoryBusinessRules.ModuleSetCategoryShouldExistWhenSelected(moduleSetCategory);

            GetByIdModuleSetCategoryResponse response = _mapper.Map<GetByIdModuleSetCategoryResponse>(moduleSetCategory);
            return response;
        }
    }
}