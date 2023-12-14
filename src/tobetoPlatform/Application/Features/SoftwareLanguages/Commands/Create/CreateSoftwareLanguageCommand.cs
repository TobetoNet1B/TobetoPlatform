using Application.Features.SoftwareLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SoftwareLanguages.Commands.Create;

public class CreateSoftwareLanguageCommand : IRequest<CreatedSoftwareLanguageResponse>
{
    public string Name { get; set; }

    public class CreateSoftwareLanguageCommandHandler : IRequestHandler<CreateSoftwareLanguageCommand, CreatedSoftwareLanguageResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISoftwareLanguageRepository _softwareLanguageRepository;
        private readonly SoftwareLanguageBusinessRules _softwareLanguageBusinessRules;

        public CreateSoftwareLanguageCommandHandler(IMapper mapper, ISoftwareLanguageRepository softwareLanguageRepository,
                                         SoftwareLanguageBusinessRules softwareLanguageBusinessRules)
        {
            _mapper = mapper;
            _softwareLanguageRepository = softwareLanguageRepository;
            _softwareLanguageBusinessRules = softwareLanguageBusinessRules;
        }

        public async Task<CreatedSoftwareLanguageResponse> Handle(CreateSoftwareLanguageCommand request, CancellationToken cancellationToken)
        {
            SoftwareLanguage softwareLanguage = _mapper.Map<SoftwareLanguage>(request);

            await _softwareLanguageRepository.AddAsync(softwareLanguage);

            CreatedSoftwareLanguageResponse response = _mapper.Map<CreatedSoftwareLanguageResponse>(softwareLanguage);
            return response;
        }
    }
}