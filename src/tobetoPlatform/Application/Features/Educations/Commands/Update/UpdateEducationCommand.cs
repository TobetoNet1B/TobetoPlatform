using Application.Features.Educations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Educations.Commands.Update;

public class UpdateEducationCommand : IRequest<UpdatedEducationResponse>
{
    public Guid Id { get; set; }
    public string University { get; set; }
    public string Department { get; set; }
    public string Graduation { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsContinueUniversity { get; set; }
    public Guid StudentId { get; set; }

    public class UpdateEducationCommandHandler : IRequestHandler<UpdateEducationCommand, UpdatedEducationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEducationRepository _educationRepository;
        private readonly EducationBusinessRules _educationBusinessRules;

        public UpdateEducationCommandHandler(IMapper mapper, IEducationRepository educationRepository,
                                         EducationBusinessRules educationBusinessRules)
        {
            _mapper = mapper;
            _educationRepository = educationRepository;
            _educationBusinessRules = educationBusinessRules;
        }

        public async Task<UpdatedEducationResponse> Handle(UpdateEducationCommand request, CancellationToken cancellationToken)
        {
            Education? education = await _educationRepository.GetAsync(predicate: e => e.Id == request.Id, cancellationToken: cancellationToken);
            await _educationBusinessRules.EducationShouldExistWhenSelected(education);
            education = _mapper.Map(request, education);

            await _educationRepository.UpdateAsync(education!);

            UpdatedEducationResponse response = _mapper.Map<UpdatedEducationResponse>(education);
            return response;
        }
    }
}