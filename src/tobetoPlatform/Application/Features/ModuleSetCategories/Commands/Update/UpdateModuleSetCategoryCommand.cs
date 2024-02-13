using Application.Features.ModuleSetCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ModuleSetCategories.Commands.Update;

public class UpdateModuleSetCategoryCommand : IRequest<UpdatedModuleSetCategoryResponse>
{
    public Guid Id { get; set; }
    public Guid ModuleSetId { get; set; }
    public Guid CategoryOfModuleSetId { get; set; }

    public class UpdateModuleSetCategoryCommandHandler : IRequestHandler<UpdateModuleSetCategoryCommand, UpdatedModuleSetCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IModuleSetCategoryRepository _moduleSetCategoryRepository;
        private readonly ModuleSetCategoryBusinessRules _moduleSetCategoryBusinessRules;

        public UpdateModuleSetCategoryCommandHandler(IMapper mapper, IModuleSetCategoryRepository moduleSetCategoryRepository,
                                         ModuleSetCategoryBusinessRules moduleSetCategoryBusinessRules)
        {
            _mapper = mapper;
            _moduleSetCategoryRepository = moduleSetCategoryRepository;
            _moduleSetCategoryBusinessRules = moduleSetCategoryBusinessRules;
        }

        public async Task<UpdatedModuleSetCategoryResponse> Handle(UpdateModuleSetCategoryCommand request, CancellationToken cancellationToken)
        {
            ModuleSetCategory? moduleSetCategory = await _moduleSetCategoryRepository.GetAsync(predicate: msc => msc.Id == request.Id, cancellationToken: cancellationToken);
            await _moduleSetCategoryBusinessRules.ModuleSetCategoryShouldExistWhenSelected(moduleSetCategory);
            moduleSetCategory = _mapper.Map(request, moduleSetCategory);

            await _moduleSetCategoryRepository.UpdateAsync(moduleSetCategory!);

            UpdatedModuleSetCategoryResponse response = _mapper.Map<UpdatedModuleSetCategoryResponse>(moduleSetCategory);
            return response;
        }
    }
}