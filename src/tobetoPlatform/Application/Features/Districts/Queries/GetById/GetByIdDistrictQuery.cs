using Application.Features.Districts.Rules;
using Application.Services.Districts;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Districts.Queries.GetById;

public class GetByIdDistrictQuery : IRequest<List<GetByIdDistrictResponse>>
{
    public Guid Id { get; set; }

    public class GetByIdDistrictQueryHandler : IRequestHandler<GetByIdDistrictQuery, List<GetByIdDistrictResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IDistrictRepository _districtRepository;
        private readonly DistrictBusinessRules _districtBusinessRules;
        private readonly IDistrictsService _districtsManager;

        public GetByIdDistrictQueryHandler(IDistrictsService districtsManager, IMapper mapper, IDistrictRepository districtRepository, DistrictBusinessRules districtBusinessRules)
        {
            _mapper = mapper;
            _districtRepository = districtRepository;
            _districtBusinessRules = districtBusinessRules;
            _districtsManager = districtsManager;
        }

        public async Task<List<GetByIdDistrictResponse>> Handle(GetByIdDistrictQuery request, CancellationToken cancellationToken)
        {
            //District? district = await _districtRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            //await _districtBusinessRules.DistrictShouldExistWhenSelected(district);

            var district = await _districtsManager.GetListAsync(
                predicate: d => d.CityId == request.Id, // CityId'ye göre filtreleme yapýlýyor
                cancellationToken: cancellationToken);

            List<GetByIdDistrictResponse> response = _mapper.Map<List<GetByIdDistrictResponse>>(district.Items);
            return response;
        }
    }
}