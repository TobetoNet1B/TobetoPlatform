using Application.Features.Appeals.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Appeals.Queries.GetById;

public class GetByIdAppealQuery : IRequest<GetByIdAppealResponse>
{
    public Guid Id { get; set; }

    public class GetByIdAppealQueryHandler : IRequestHandler<GetByIdAppealQuery, GetByIdAppealResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAppealRepository _appealRepository;
        private readonly AppealBusinessRules _appealBusinessRules;

        public GetByIdAppealQueryHandler(IMapper mapper, IAppealRepository appealRepository, AppealBusinessRules appealBusinessRules)
        {
            _mapper = mapper;
            _appealRepository = appealRepository;
            _appealBusinessRules = appealBusinessRules;
        }

        public async Task<GetByIdAppealResponse> Handle(GetByIdAppealQuery request, CancellationToken cancellationToken)
        {
            Appeal? appeal = await _appealRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _appealBusinessRules.AppealShouldExistWhenSelected(appeal);

            GetByIdAppealResponse response = _mapper.Map<GetByIdAppealResponse>(appeal);
            return response;
        }
    }
}