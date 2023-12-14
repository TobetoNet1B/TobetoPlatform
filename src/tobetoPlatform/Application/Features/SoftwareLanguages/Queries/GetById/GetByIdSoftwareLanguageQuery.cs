using Application.Features.SoftwareLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SoftwareLanguages.Queries.GetById;

public class GetByIdSoftwareLanguageQuery : IRequest<GetByIdSoftwareLanguageResponse>
{
    public Guid Id { get; set; }

    public class GetByIdSoftwareLanguageQueryHandler : IRequestHandler<GetByIdSoftwareLanguageQuery, GetByIdSoftwareLanguageResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISoftwareLanguageRepository _softwareLanguageRepository;
        private readonly SoftwareLanguageBusinessRules _softwareLanguageBusinessRules;

        public GetByIdSoftwareLanguageQueryHandler(IMapper mapper, ISoftwareLanguageRepository softwareLanguageRepository, SoftwareLanguageBusinessRules softwareLanguageBusinessRules)
        {
            _mapper = mapper;
            _softwareLanguageRepository = softwareLanguageRepository;
            _softwareLanguageBusinessRules = softwareLanguageBusinessRules;
        }

        public async Task<GetByIdSoftwareLanguageResponse> Handle(GetByIdSoftwareLanguageQuery request, CancellationToken cancellationToken)
        {
            SoftwareLanguage? softwareLanguage = await _softwareLanguageRepository.GetAsync(predicate: sl => sl.Id == request.Id, cancellationToken: cancellationToken);
            await _softwareLanguageBusinessRules.SoftwareLanguageShouldExistWhenSelected(softwareLanguage);

            GetByIdSoftwareLanguageResponse response = _mapper.Map<GetByIdSoftwareLanguageResponse>(softwareLanguage);
            return response;
        }
    }
}