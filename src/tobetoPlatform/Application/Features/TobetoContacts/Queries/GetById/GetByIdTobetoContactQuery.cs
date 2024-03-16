using Application.Features.TobetoContacts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.TobetoContacts.Queries.GetById;

public class GetByIdTobetoContactQuery : IRequest<GetByIdTobetoContactResponse>
{
    public Guid Id { get; set; }

    public class GetByIdTobetoContactQueryHandler : IRequestHandler<GetByIdTobetoContactQuery, GetByIdTobetoContactResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITobetoContactRepository _tobetoContactRepository;
        private readonly TobetoContactBusinessRules _tobetoContactBusinessRules;

        public GetByIdTobetoContactQueryHandler(IMapper mapper, ITobetoContactRepository tobetoContactRepository, TobetoContactBusinessRules tobetoContactBusinessRules)
        {
            _mapper = mapper;
            _tobetoContactRepository = tobetoContactRepository;
            _tobetoContactBusinessRules = tobetoContactBusinessRules;
        }

        public async Task<GetByIdTobetoContactResponse> Handle(GetByIdTobetoContactQuery request, CancellationToken cancellationToken)
        {
            TobetoContact? tobetoContact = await _tobetoContactRepository.GetAsync(predicate: tc => tc.Id == request.Id, cancellationToken: cancellationToken);
            await _tobetoContactBusinessRules.TobetoContactShouldExistWhenSelected(tobetoContact);

            GetByIdTobetoContactResponse response = _mapper.Map<GetByIdTobetoContactResponse>(tobetoContact);
            return response;
        }
    }
}