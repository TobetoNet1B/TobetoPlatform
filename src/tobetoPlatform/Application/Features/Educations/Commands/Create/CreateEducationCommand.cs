using Application.Features.Educations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Educations.Commands.Create;

public class CreateEducationCommand : IRequest<CreatedEducationResponse>
{
    public string University { get; set; }
    public string Department { get; set; }
    public string Graduation { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsContinueUniversity { get; set; }
    public Guid StudentId { get; set; }

    public class CreateEducationCommandHandler : IRequestHandler<CreateEducationCommand, CreatedEducationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEducationRepository _educationRepository;
        private readonly EducationBusinessRules _educationBusinessRules;

        public CreateEducationCommandHandler(IMapper mapper, IEducationRepository educationRepository,
                                         EducationBusinessRules educationBusinessRules)
        {
            _mapper = mapper;
            _educationRepository = educationRepository;
            _educationBusinessRules = educationBusinessRules;
        }

        public async Task<CreatedEducationResponse> Handle(CreateEducationCommand request, CancellationToken cancellationToken)
        {
            Education education = _mapper.Map<Education>(request);

            await _educationRepository.AddAsync(education);

            CreatedEducationResponse response = _mapper.Map<CreatedEducationResponse>(education);
            return response;
        }
    }
}