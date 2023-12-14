using Application.Features.ForeignLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ForeignLanguages.Commands.Create;

public class CreateForeignLanguageCommand : IRequest<CreatedForeignLanguageResponse>
{
    public string Name { get; set; }
    public Guid ForeignLanguageLevelId { get; set; }
    public Guid StudentId { get; set; }

    public class CreateForeignLanguageCommandHandler : IRequestHandler<CreateForeignLanguageCommand, CreatedForeignLanguageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IForeignLanguageRepository _foreignLanguageRepository;
        private readonly ForeignLanguageBusinessRules _foreignLanguageBusinessRules;

        public CreateForeignLanguageCommandHandler(IMapper mapper, IForeignLanguageRepository foreignLanguageRepository,
                                         ForeignLanguageBusinessRules foreignLanguageBusinessRules)
        {
            _mapper = mapper;
            _foreignLanguageRepository = foreignLanguageRepository;
            _foreignLanguageBusinessRules = foreignLanguageBusinessRules;
        }

        public async Task<CreatedForeignLanguageResponse> Handle(CreateForeignLanguageCommand request, CancellationToken cancellationToken)
        {
            ForeignLanguage foreignLanguage = _mapper.Map<ForeignLanguage>(request);

            await _foreignLanguageRepository.AddAsync(foreignLanguage);

            CreatedForeignLanguageResponse response = _mapper.Map<CreatedForeignLanguageResponse>(foreignLanguage);
            return response;
        }
    }
}