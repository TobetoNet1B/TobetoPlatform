using Application.Features.ForeignLanguages.Constants;
using Application.Features.ForeignLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ForeignLanguages.Commands.Delete;

public class DeleteForeignLanguageCommand : IRequest<DeletedForeignLanguageResponse>
{
    public Guid Id { get; set; }

    public class DeleteForeignLanguageCommandHandler : IRequestHandler<DeleteForeignLanguageCommand, DeletedForeignLanguageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IForeignLanguageRepository _foreignLanguageRepository;
        private readonly ForeignLanguageBusinessRules _foreignLanguageBusinessRules;

        public DeleteForeignLanguageCommandHandler(IMapper mapper, IForeignLanguageRepository foreignLanguageRepository,
                                         ForeignLanguageBusinessRules foreignLanguageBusinessRules)
        {
            _mapper = mapper;
            _foreignLanguageRepository = foreignLanguageRepository;
            _foreignLanguageBusinessRules = foreignLanguageBusinessRules;
        }

        public async Task<DeletedForeignLanguageResponse> Handle(DeleteForeignLanguageCommand request, CancellationToken cancellationToken)
        {
            ForeignLanguage? foreignLanguage = await _foreignLanguageRepository.GetAsync(predicate: fl => fl.Id == request.Id, cancellationToken: cancellationToken);
            await _foreignLanguageBusinessRules.ForeignLanguageShouldExistWhenSelected(foreignLanguage);

            await _foreignLanguageRepository.DeleteAsync(foreignLanguage!);

            DeletedForeignLanguageResponse response = _mapper.Map<DeletedForeignLanguageResponse>(foreignLanguage);
            return response;
        }
    }
}