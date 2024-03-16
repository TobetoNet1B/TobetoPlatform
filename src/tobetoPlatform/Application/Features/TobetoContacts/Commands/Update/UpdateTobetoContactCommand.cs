using Application.Features.TobetoContacts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.TobetoContacts.Commands.Update;

public class UpdateTobetoContactCommand : IRequest<UpdatedTobetoContactResponse>
{
    public Guid Id { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? Message { get; set; }
    public bool? IsReaded { get; set; }

    public class UpdateTobetoContactCommandHandler : IRequestHandler<UpdateTobetoContactCommand, UpdatedTobetoContactResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITobetoContactRepository _tobetoContactRepository;
        private readonly TobetoContactBusinessRules _tobetoContactBusinessRules;

        public UpdateTobetoContactCommandHandler(IMapper mapper, ITobetoContactRepository tobetoContactRepository,
                                         TobetoContactBusinessRules tobetoContactBusinessRules)
        {
            _mapper = mapper;
            _tobetoContactRepository = tobetoContactRepository;
            _tobetoContactBusinessRules = tobetoContactBusinessRules;
        }

        public async Task<UpdatedTobetoContactResponse> Handle(UpdateTobetoContactCommand request, CancellationToken cancellationToken)
        {
            TobetoContact? tobetoContact = await _tobetoContactRepository.GetAsync(predicate: tc => tc.Id == request.Id, cancellationToken: cancellationToken);
            await _tobetoContactBusinessRules.TobetoContactShouldExistWhenSelected(tobetoContact);
            tobetoContact = _mapper.Map(request, tobetoContact);

            await _tobetoContactRepository.UpdateAsync(tobetoContact!);

            UpdatedTobetoContactResponse response = _mapper.Map<UpdatedTobetoContactResponse>(tobetoContact);
            return response;
        }
    }
}