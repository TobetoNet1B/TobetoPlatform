using Application.Features.ForeignLanguageLevels.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ForeignLanguageLevels.Commands.Create;

public class CreateForeignLanguageLevelCommand : IRequest<CreatedForeignLanguageLevelResponse>
{
    public string Name { get; set; }
    public Guid ForeignLanguageId { get; set; }

    public class CreateForeignLanguageLevelCommandHandler : IRequestHandler<CreateForeignLanguageLevelCommand, CreatedForeignLanguageLevelResponse>
    {
        private readonly IMapper _mapper;
        private readonly IForeignLanguageLevelRepository _foreignLanguageLevelRepository;
        private readonly ForeignLanguageLevelBusinessRules _foreignLanguageLevelBusinessRules;

        public CreateForeignLanguageLevelCommandHandler(IMapper mapper, IForeignLanguageLevelRepository foreignLanguageLevelRepository,
                                         ForeignLanguageLevelBusinessRules foreignLanguageLevelBusinessRules)
        {
            _mapper = mapper;
            _foreignLanguageLevelRepository = foreignLanguageLevelRepository;
            _foreignLanguageLevelBusinessRules = foreignLanguageLevelBusinessRules;
        }

        public async Task<CreatedForeignLanguageLevelResponse> Handle(CreateForeignLanguageLevelCommand request, CancellationToken cancellationToken)
        {
            ForeignLanguageLevel foreignLanguageLevel = _mapper.Map<ForeignLanguageLevel>(request);

            await _foreignLanguageLevelRepository.AddAsync(foreignLanguageLevel);

            CreatedForeignLanguageLevelResponse response = _mapper.Map<CreatedForeignLanguageLevelResponse>(foreignLanguageLevel);
            return response;
        }
    }
}