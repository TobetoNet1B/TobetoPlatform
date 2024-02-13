using Application.Features.CategoryOfModuleSets.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CategoryOfModuleSets.Queries.GetById;

public class GetByIdCategoryOfModuleSetQuery : IRequest<GetByIdCategoryOfModuleSetResponse>
{
    public Guid Id { get; set; }

    public class GetByIdCategoryOfModuleSetQueryHandler : IRequestHandler<GetByIdCategoryOfModuleSetQuery, GetByIdCategoryOfModuleSetResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryOfModuleSetRepository _categoryOfModuleSetRepository;
        private readonly CategoryOfModuleSetBusinessRules _categoryOfModuleSetBusinessRules;

        public GetByIdCategoryOfModuleSetQueryHandler(IMapper mapper, ICategoryOfModuleSetRepository categoryOfModuleSetRepository, CategoryOfModuleSetBusinessRules categoryOfModuleSetBusinessRules)
        {
            _mapper = mapper;
            _categoryOfModuleSetRepository = categoryOfModuleSetRepository;
            _categoryOfModuleSetBusinessRules = categoryOfModuleSetBusinessRules;
        }

        public async Task<GetByIdCategoryOfModuleSetResponse> Handle(GetByIdCategoryOfModuleSetQuery request, CancellationToken cancellationToken)
        {
            CategoryOfModuleSet? categoryOfModuleSet = await _categoryOfModuleSetRepository.GetAsync(predicate: coms => coms.Id == request.Id, cancellationToken: cancellationToken);
            await _categoryOfModuleSetBusinessRules.CategoryOfModuleSetShouldExistWhenSelected(categoryOfModuleSet);

            GetByIdCategoryOfModuleSetResponse response = _mapper.Map<GetByIdCategoryOfModuleSetResponse>(categoryOfModuleSet);
            return response;
        }
    }
}