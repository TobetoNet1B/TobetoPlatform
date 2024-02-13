using Application.Features.ModuleSetCategories.Constants;
using Application.Features.ModuleSetCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ModuleSetCategories.Commands.Delete;

public class DeleteModuleSetCategoryCommand : IRequest<DeletedModuleSetCategoryResponse>
{
    public Guid Id { get; set; }

    public class DeleteModuleSetCategoryCommandHandler : IRequestHandler<DeleteModuleSetCategoryCommand, DeletedModuleSetCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IModuleSetCategoryRepository _moduleSetCategoryRepository;
        private readonly ModuleSetCategoryBusinessRules _moduleSetCategoryBusinessRules;

        public DeleteModuleSetCategoryCommandHandler(IMapper mapper, IModuleSetCategoryRepository moduleSetCategoryRepository,
                                         ModuleSetCategoryBusinessRules moduleSetCategoryBusinessRules)
        {
            _mapper = mapper;
            _moduleSetCategoryRepository = moduleSetCategoryRepository;
            _moduleSetCategoryBusinessRules = moduleSetCategoryBusinessRules;
        }

        public async Task<DeletedModuleSetCategoryResponse> Handle(DeleteModuleSetCategoryCommand request, CancellationToken cancellationToken)
        {
            ModuleSetCategory? moduleSetCategory = await _moduleSetCategoryRepository.GetAsync(predicate: msc => msc.Id == request.Id, cancellationToken: cancellationToken);
            await _moduleSetCategoryBusinessRules.ModuleSetCategoryShouldExistWhenSelected(moduleSetCategory);

            await _moduleSetCategoryRepository.DeleteAsync(moduleSetCategory!);

            DeletedModuleSetCategoryResponse response = _mapper.Map<DeletedModuleSetCategoryResponse>(moduleSetCategory);
            return response;
        }
    }
}