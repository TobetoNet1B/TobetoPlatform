using Application.Features.Educations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Educations.Queries.GetById;

public class GetByIdEducationQuery : IRequest<GetByIdEducationResponse>
{
    public Guid Id { get; set; }

    public class GetByIdEducationQueryHandler : IRequestHandler<GetByIdEducationQuery, GetByIdEducationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEducationRepository _educationRepository;
        private readonly EducationBusinessRules _educationBusinessRules;

        public GetByIdEducationQueryHandler(IMapper mapper, IEducationRepository educationRepository, EducationBusinessRules educationBusinessRules)
        {
            _mapper = mapper;
            _educationRepository = educationRepository;
            _educationBusinessRules = educationBusinessRules;
        }

        public async Task<GetByIdEducationResponse> Handle(GetByIdEducationQuery request, CancellationToken cancellationToken)
        {
            Education? education = await _educationRepository.GetAsync(predicate: e => e.Id == request.Id, cancellationToken: cancellationToken);
            await _educationBusinessRules.EducationShouldExistWhenSelected(education);

            GetByIdEducationResponse response = _mapper.Map<GetByIdEducationResponse>(education);
            return response;
        }
    }
}