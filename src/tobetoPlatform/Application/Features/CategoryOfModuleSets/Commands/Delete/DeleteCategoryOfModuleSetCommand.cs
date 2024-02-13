using Application.Features.CategoryOfModuleSets.Constants;
using Application.Features.CategoryOfModuleSets.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CategoryOfModuleSets.Commands.Delete;

public class DeleteCategoryOfModuleSetCommand : IRequest<DeletedCategoryOfModuleSetResponse>
{
    public Guid Id { get; set; }

    public class DeleteCategoryOfModuleSetCommandHandler : IRequestHandler<DeleteCategoryOfModuleSetCommand, DeletedCategoryOfModuleSetResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryOfModuleSetRepository _categoryOfModuleSetRepository;
        private readonly CategoryOfModuleSetBusinessRules _categoryOfModuleSetBusinessRules;

        public DeleteCategoryOfModuleSetCommandHandler(IMapper mapper, ICategoryOfModuleSetRepository categoryOfModuleSetRepository,
                                         CategoryOfModuleSetBusinessRules categoryOfModuleSetBusinessRules)
        {
            _mapper = mapper;
            _categoryOfModuleSetRepository = categoryOfModuleSetRepository;
            _categoryOfModuleSetBusinessRules = categoryOfModuleSetBusinessRules;
        }

        public async Task<DeletedCategoryOfModuleSetResponse> Handle(DeleteCategoryOfModuleSetCommand request, CancellationToken cancellationToken)
        {
            CategoryOfModuleSet? categoryOfModuleSet = await _categoryOfModuleSetRepository.GetAsync(predicate: coms => coms.Id == request.Id, cancellationToken: cancellationToken);
            await _categoryOfModuleSetBusinessRules.CategoryOfModuleSetShouldExistWhenSelected(categoryOfModuleSet);

            await _categoryOfModuleSetRepository.DeleteAsync(categoryOfModuleSet!);

            DeletedCategoryOfModuleSetResponse response = _mapper.Map<DeletedCategoryOfModuleSetResponse>(categoryOfModuleSet);
            return response;
        }
    }
}