using Application.Features.SoftwareLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SoftwareLanguages.Commands.Update;

public class UpdateSoftwareLanguageCommand : IRequest<UpdatedSoftwareLanguageResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public class UpdateSoftwareLanguageCommandHandler : IRequestHandler<UpdateSoftwareLanguageCommand, UpdatedSoftwareLanguageResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISoftwareLanguageRepository _softwareLanguageRepository;
        private readonly SoftwareLanguageBusinessRules _softwareLanguageBusinessRules;

        public UpdateSoftwareLanguageCommandHandler(IMapper mapper, ISoftwareLanguageRepository softwareLanguageRepository,
                                         SoftwareLanguageBusinessRules softwareLanguageBusinessRules)
        {
            _mapper = mapper;
            _softwareLanguageRepository = softwareLanguageRepository;
            _softwareLanguageBusinessRules = softwareLanguageBusinessRules;
        }

        public async Task<UpdatedSoftwareLanguageResponse> Handle(UpdateSoftwareLanguageCommand request, CancellationToken cancellationToken)
        {
            SoftwareLanguage? softwareLanguage = await _softwareLanguageRepository.GetAsync(predicate: sl => sl.Id == request.Id, cancellationToken: cancellationToken);
            await _softwareLanguageBusinessRules.SoftwareLanguageShouldExistWhenSelected(softwareLanguage);
            softwareLanguage = _mapper.Map(request, softwareLanguage);

            await _softwareLanguageRepository.UpdateAsync(softwareLanguage!);

            UpdatedSoftwareLanguageResponse response = _mapper.Map<UpdatedSoftwareLanguageResponse>(softwareLanguage);
            return response;
        }
    }
}