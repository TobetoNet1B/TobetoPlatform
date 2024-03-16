using Application.Features.TobetoContacts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.TobetoContacts.Commands.Create;

public class CreateTobetoContactCommand : IRequest<CreatedTobetoContactResponse>
{
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? Message { get; set; }
    public bool? IsReaded { get; set; }

    public class CreateTobetoContactCommandHandler : IRequestHandler<CreateTobetoContactCommand, CreatedTobetoContactResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITobetoContactRepository _tobetoContactRepository;
        private readonly TobetoContactBusinessRules _tobetoContactBusinessRules;

        public CreateTobetoContactCommandHandler(IMapper mapper, ITobetoContactRepository tobetoContactRepository,
                                         TobetoContactBusinessRules tobetoContactBusinessRules)
        {
            _mapper = mapper;
            _tobetoContactRepository = tobetoContactRepository;
            _tobetoContactBusinessRules = tobetoContactBusinessRules;
        }

        public async Task<CreatedTobetoContactResponse> Handle(CreateTobetoContactCommand request, CancellationToken cancellationToken)
        {
            TobetoContact tobetoContact = _mapper.Map<TobetoContact>(request);

            await _tobetoContactRepository.AddAsync(tobetoContact);

            CreatedTobetoContactResponse response = _mapper.Map<CreatedTobetoContactResponse>(tobetoContact);
            return response;
        }
    }
}