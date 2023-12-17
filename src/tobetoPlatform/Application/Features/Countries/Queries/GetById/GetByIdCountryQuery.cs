using Application.Features.Countries.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Countries.Queries.GetById;

public class GetByIdCountryQuery : IRequest<GetByIdCountryResponse>
{
    public Guid Id { get; set; }

    public class GetByIdCountryQueryHandler : IRequestHandler<GetByIdCountryQuery, GetByIdCountryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;
        private readonly CountryBusinessRules _countryBusinessRules;

        public GetByIdCountryQueryHandler(IMapper mapper, ICountryRepository countryRepository, CountryBusinessRules countryBusinessRules)
        {
            _mapper = mapper;
            _countryRepository = countryRepository;
            _countryBusinessRules = countryBusinessRules;
        }

        public async Task<GetByIdCountryResponse> Handle(GetByIdCountryQuery request, CancellationToken cancellationToken)
        {
            Country? country = await _countryRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _countryBusinessRules.CountryShouldExistWhenSelected(country);

            GetByIdCountryResponse response = _mapper.Map<GetByIdCountryResponse>(country);
            return response;
        }
    }
}