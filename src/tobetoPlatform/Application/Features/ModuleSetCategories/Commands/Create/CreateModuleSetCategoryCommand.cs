using Application.Features.ModuleSetCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ModuleSetCategories.Commands.Create;

public class CreateModuleSetCategoryCommand : IRequest<CreatedModuleSetCategoryResponse>
{
    public Guid ModuleSetId { get; set; }
    public Guid CategoryOfModuleSetId { get; set; }

    public class CreateModuleSetCategoryCommandHandler : IRequestHandler<CreateModuleSetCategoryCommand, CreatedModuleSetCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IModuleSetCategoryRepository _moduleSetCategoryRepository;
        private readonly ModuleSetCategoryBusinessRules _moduleSetCategoryBusinessRules;

        public CreateModuleSetCategoryCommandHandler(IMapper mapper, IModuleSetCategoryRepository moduleSetCategoryRepository,
                                         ModuleSetCategoryBusinessRules moduleSetCategoryBusinessRules)
        {
            _mapper = mapper;
            _moduleSetCategoryRepository = moduleSetCategoryRepository;
            _moduleSetCategoryBusinessRules = moduleSetCategoryBusinessRules;
        }

        public async Task<CreatedModuleSetCategoryResponse> Handle(CreateModuleSetCategoryCommand request, CancellationToken cancellationToken)
        {
            ModuleSetCategory moduleSetCategory = _mapper.Map<ModuleSetCategory>(request);

            await _moduleSetCategoryRepository.AddAsync(moduleSetCategory);

            CreatedModuleSetCategoryResponse response = _mapper.Map<CreatedModuleSetCategoryResponse>(moduleSetCategory);
            return response;
        }
    }
}