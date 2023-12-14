using Application.Features.StudentAppeals.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentAppeals.Commands.Create;

public class CreateStudentAppealCommand : IRequest<CreatedStudentAppealResponse>
{
    public Guid AppealId { get; set; }
    public Guid StudentId { get; set; }
    public bool IsApproved { get; set; }

    public class CreateStudentAppealCommandHandler : IRequestHandler<CreateStudentAppealCommand, CreatedStudentAppealResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentAppealRepository _studentAppealRepository;
        private readonly StudentAppealBusinessRules _studentAppealBusinessRules;

        public CreateStudentAppealCommandHandler(IMapper mapper, IStudentAppealRepository studentAppealRepository,
                                         StudentAppealBusinessRules studentAppealBusinessRules)
        {
            _mapper = mapper;
            _studentAppealRepository = studentAppealRepository;
            _studentAppealBusinessRules = studentAppealBusinessRules;
        }

        public async Task<CreatedStudentAppealResponse> Handle(CreateStudentAppealCommand request, CancellationToken cancellationToken)
        {
            StudentAppeal studentAppeal = _mapper.Map<StudentAppeal>(request);

            await _studentAppealRepository.AddAsync(studentAppeal);

            CreatedStudentAppealResponse response = _mapper.Map<CreatedStudentAppealResponse>(studentAppeal);
            return response;
        }
    }
}