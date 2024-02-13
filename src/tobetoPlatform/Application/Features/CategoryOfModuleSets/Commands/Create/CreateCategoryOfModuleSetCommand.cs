using Application.Features.CategoryOfModuleSets.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CategoryOfModuleSets.Commands.Create;

public class CreateCategoryOfModuleSetCommand : IRequest<CreatedCategoryOfModuleSetResponse>
{
    public string Name { get; set; }
    public bool? IsActive { get; set; }

    public class CreateCategoryOfModuleSetCommandHandler : IRequestHandler<CreateCategoryOfModuleSetCommand, CreatedCategoryOfModuleSetResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryOfModuleSetRepository _categoryOfModuleSetRepository;
        private readonly CategoryOfModuleSetBusinessRules _categoryOfModuleSetBusinessRules;

        public CreateCategoryOfModuleSetCommandHandler(IMapper mapper, ICategoryOfModuleSetRepository categoryOfModuleSetRepository,
                                         CategoryOfModuleSetBusinessRules categoryOfModuleSetBusinessRules)
        {
            _mapper = mapper;
            _categoryOfModuleSetRepository = categoryOfModuleSetRepository;
            _categoryOfModuleSetBusinessRules = categoryOfModuleSetBusinessRules;
        }

        public async Task<CreatedCategoryOfModuleSetResponse> Handle(CreateCategoryOfModuleSetCommand request, CancellationToken cancellationToken)
        {
            CategoryOfModuleSet categoryOfModuleSet = _mapper.Map<CategoryOfModuleSet>(request);

            await _categoryOfModuleSetRepository.AddAsync(categoryOfModuleSet);

            CreatedCategoryOfModuleSetResponse response = _mapper.Map<CreatedCategoryOfModuleSetResponse>(categoryOfModuleSet);
            return response;
        }
    }
}