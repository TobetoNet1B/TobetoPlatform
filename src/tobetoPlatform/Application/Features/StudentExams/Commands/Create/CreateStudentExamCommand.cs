using Application.Features.StudentExams.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentExams.Commands.Create;

public class CreateStudentExamCommand : IRequest<CreatedStudentExamResponse>
{
    public Guid StudentId { get; set; }
    public Guid ExamId { get; set; }
    public bool IsAttended { get; set; }
    public int? CountOfTrue { get; set; }
    public int? CountOfFalse { get; set; }
    public int? CountOfEmpty { get; set; }
    public int? Score { get; set; }

    public class CreateStudentExamCommandHandler : IRequestHandler<CreateStudentExamCommand, CreatedStudentExamResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentExamRepository _studentExamRepository;
        private readonly StudentExamBusinessRules _studentExamBusinessRules;

        public CreateStudentExamCommandHandler(IMapper mapper, IStudentExamRepository studentExamRepository,
                                         StudentExamBusinessRules studentExamBusinessRules)
        {
            _mapper = mapper;
            _studentExamRepository = studentExamRepository;
            _studentExamBusinessRules = studentExamBusinessRules;
        }

        public async Task<CreatedStudentExamResponse> Handle(CreateStudentExamCommand request, CancellationToken cancellationToken)
        {
            StudentExam studentExam = _mapper.Map<StudentExam>(request);

            await _studentExamRepository.AddAsync(studentExam);

            CreatedStudentExamResponse response = _mapper.Map<CreatedStudentExamResponse>(studentExam);
            return response;
        }
    }
}