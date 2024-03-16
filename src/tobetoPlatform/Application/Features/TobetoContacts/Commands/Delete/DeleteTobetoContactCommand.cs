using Application.Features.TobetoContacts.Constants;
using Application.Features.TobetoContacts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.TobetoContacts.Commands.Delete;

public class DeleteTobetoContactCommand : IRequest<DeletedTobetoContactResponse>
{
    public Guid Id { get; set; }

    public class DeleteTobetoContactCommandHandler : IRequestHandler<DeleteTobetoContactCommand, DeletedTobetoContactResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITobetoContactRepository _tobetoContactRepository;
        private readonly TobetoContactBusinessRules _tobetoContactBusinessRules;

        public DeleteTobetoContactCommandHandler(IMapper mapper, ITobetoContactRepository tobetoContactRepository,
                                         TobetoContactBusinessRules tobetoContactBusinessRules)
        {
            _mapper = mapper;
            _tobetoContactRepository = tobetoContactRepository;
            _tobetoContactBusinessRules = tobetoContactBusinessRules;
        }

        public async Task<DeletedTobetoContactResponse> Handle(DeleteTobetoContactCommand request, CancellationToken cancellationToken)
        {
            TobetoContact? tobetoContact = await _tobetoContactRepository.GetAsync(predicate: tc => tc.Id == request.Id, cancellationToken: cancellationToken);
            await _tobetoContactBusinessRules.TobetoContactShouldExistWhenSelected(tobetoContact);

            await _tobetoContactRepository.DeleteAsync(tobetoContact!);

            DeletedTobetoContactResponse response = _mapper.Map<DeletedTobetoContactResponse>(tobetoContact);
            return response;
        }
    }
}