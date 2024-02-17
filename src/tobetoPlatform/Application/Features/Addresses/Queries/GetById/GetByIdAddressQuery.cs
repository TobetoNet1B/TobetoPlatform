using Application.Features.Addresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Addresses.Queries.GetById;

public class GetByIdAddressQuery : IRequest<GetByIdAddressResponse>
{
    public Guid Id { get; set; }

    public class GetByIdAddressQueryHandler : IRequestHandler<GetByIdAddressQuery, GetByIdAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAddressRepository _addressRepository;
        private readonly AddressBusinessRules _addressBusinessRules;

        public GetByIdAddressQueryHandler(IMapper mapper, IAddressRepository addressRepository, AddressBusinessRules addressBusinessRules)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
            _addressBusinessRules = addressBusinessRules;
        }

        public async Task<GetByIdAddressResponse> Handle(GetByIdAddressQuery request, CancellationToken cancellationToken)
        {
            Address? address = await _addressRepository.GetAsync(
                include: q => q.Include(a => a.Student)
                               .Include(a => a.Country)
                               .Include(a => a.City)
                               .Include(a => a.District),
                predicate: a => a.StudentId == request.Id,
                cancellationToken: cancellationToken);
            //await _addressBusinessRules.AddressShouldExistWhenSelected(address);

            GetByIdAddressResponse response = _mapper.Map<GetByIdAddressResponse>(address);
            return response;
        }
    }
}