using Application.Features.Appeals.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Appeals.Commands.Update;

public class UpdateAppealCommand : IRequest<UpdatedAppealResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public class UpdateAppealCommandHandler : IRequestHandler<UpdateAppealCommand, UpdatedAppealResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAppealRepository _appealRepository;
        private readonly AppealBusinessRules _appealBusinessRules;

        public UpdateAppealCommandHandler(IMapper mapper, IAppealRepository appealRepository,
                                         AppealBusinessRules appealBusinessRules)
        {
            _mapper = mapper;
            _appealRepository = appealRepository;
            _appealBusinessRules = appealBusinessRules;
        }

        public async Task<UpdatedAppealResponse> Handle(UpdateAppealCommand request, CancellationToken cancellationToken)
        {
            Appeal? appeal = await _appealRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _appealBusinessRules.AppealShouldExistWhenSelected(appeal);
            appeal = _mapper.Map(request, appeal);

            await _appealRepository.UpdateAsync(appeal!);

            UpdatedAppealResponse response = _mapper.Map<UpdatedAppealResponse>(appeal);
            return response;
        }
    }
}