using Application.Features.Appeals.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Appeals.Commands.Create;

public class CreateAppealCommand : IRequest<CreatedAppealResponse>
{
    public string Name { get; set; }
    public string Description { get; set; }

    public class CreateAppealCommandHandler : IRequestHandler<CreateAppealCommand, CreatedAppealResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAppealRepository _appealRepository;
        private readonly AppealBusinessRules _appealBusinessRules;

        public CreateAppealCommandHandler(IMapper mapper, IAppealRepository appealRepository,
                                         AppealBusinessRules appealBusinessRules)
        {
            _mapper = mapper;
            _appealRepository = appealRepository;
            _appealBusinessRules = appealBusinessRules;
        }

        public async Task<CreatedAppealResponse> Handle(CreateAppealCommand request, CancellationToken cancellationToken)
        {
            Appeal appeal = _mapper.Map<Appeal>(request);

            await _appealRepository.AddAsync(appeal);

            CreatedAppealResponse response = _mapper.Map<CreatedAppealResponse>(appeal);
            return response;
        }
    }
}