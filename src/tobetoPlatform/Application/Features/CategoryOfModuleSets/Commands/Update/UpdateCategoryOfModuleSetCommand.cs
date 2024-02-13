using Application.Features.CategoryOfModuleSets.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CategoryOfModuleSets.Commands.Update;

public class UpdateCategoryOfModuleSetCommand : IRequest<UpdatedCategoryOfModuleSetResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool? IsActive { get; set; }

    public class UpdateCategoryOfModuleSetCommandHandler : IRequestHandler<UpdateCategoryOfModuleSetCommand, UpdatedCategoryOfModuleSetResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryOfModuleSetRepository _categoryOfModuleSetRepository;
        private readonly CategoryOfModuleSetBusinessRules _categoryOfModuleSetBusinessRules;

        public UpdateCategoryOfModuleSetCommandHandler(IMapper mapper, ICategoryOfModuleSetRepository categoryOfModuleSetRepository,
                                         CategoryOfModuleSetBusinessRules categoryOfModuleSetBusinessRules)
        {
            _mapper = mapper;
            _categoryOfModuleSetRepository = categoryOfModuleSetRepository;
            _categoryOfModuleSetBusinessRules = categoryOfModuleSetBusinessRules;
        }

        public async Task<UpdatedCategoryOfModuleSetResponse> Handle(UpdateCategoryOfModuleSetCommand request, CancellationToken cancellationToken)
        {
            CategoryOfModuleSet? categoryOfModuleSet = await _categoryOfModuleSetRepository.GetAsync(predicate: coms => coms.Id == request.Id, cancellationToken: cancellationToken);
            await _categoryOfModuleSetBusinessRules.CategoryOfModuleSetShouldExistWhenSelected(categoryOfModuleSet);
            categoryOfModuleSet = _mapper.Map(request, categoryOfModuleSet);

            await _categoryOfModuleSetRepository.UpdateAsync(categoryOfModuleSet!);

            UpdatedCategoryOfModuleSetResponse response = _mapper.Map<UpdatedCategoryOfModuleSetResponse>(categoryOfModuleSet);
            return response;
        }
    }
}