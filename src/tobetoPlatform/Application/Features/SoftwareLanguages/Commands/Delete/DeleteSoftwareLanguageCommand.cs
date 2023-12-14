using Application.Features.SoftwareLanguages.Constants;
using Application.Features.SoftwareLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SoftwareLanguages.Commands.Delete;

public class DeleteSoftwareLanguageCommand : IRequest<DeletedSoftwareLanguageResponse>
{
    public Guid Id { get; set; }

    public class DeleteSoftwareLanguageCommandHandler : IRequestHandler<DeleteSoftwareLanguageCommand, DeletedSoftwareLanguageResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISoftwareLanguageRepository _softwareLanguageRepository;
        private readonly SoftwareLanguageBusinessRules _softwareLanguageBusinessRules;

        public DeleteSoftwareLanguageCommandHandler(IMapper mapper, ISoftwareLanguageRepository softwareLanguageRepository,
                                         SoftwareLanguageBusinessRules softwareLanguageBusinessRules)
        {
            _mapper = mapper;
            _softwareLanguageRepository = softwareLanguageRepository;
            _softwareLanguageBusinessRules = softwareLanguageBusinessRules;
        }

        public async Task<DeletedSoftwareLanguageResponse> Handle(DeleteSoftwareLanguageCommand request, CancellationToken cancellationToken)
        {
            SoftwareLanguage? softwareLanguage = await _softwareLanguageRepository.GetAsync(predicate: sl => sl.Id == request.Id, cancellationToken: cancellationToken);
            await _softwareLanguageBusinessRules.SoftwareLanguageShouldExistWhenSelected(softwareLanguage);

            await _softwareLanguageRepository.DeleteAsync(softwareLanguage!);

            DeletedSoftwareLanguageResponse response = _mapper.Map<DeletedSoftwareLanguageResponse>(softwareLanguage);
            return response;
        }
    }
}