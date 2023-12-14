using Application.Features.StudentExams.Constants;
using Application.Features.StudentExams.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentExams.Commands.Delete;

public class DeleteStudentExamCommand : IRequest<DeletedStudentExamResponse>
{
    public Guid Id { get; set; }

    public class DeleteStudentExamCommandHandler : IRequestHandler<DeleteStudentExamCommand, DeletedStudentExamResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentExamRepository _studentExamRepository;
        private readonly StudentExamBusinessRules _studentExamBusinessRules;

        public DeleteStudentExamCommandHandler(IMapper mapper, IStudentExamRepository studentExamRepository,
                                         StudentExamBusinessRules studentExamBusinessRules)
        {
            _mapper = mapper;
            _studentExamRepository = studentExamRepository;
            _studentExamBusinessRules = studentExamBusinessRules;
        }

        public async Task<DeletedStudentExamResponse> Handle(DeleteStudentExamCommand request, CancellationToken cancellationToken)
        {
            StudentExam? studentExam = await _studentExamRepository.GetAsync(predicate: se => se.Id == request.Id, cancellationToken: cancellationToken);
            await _studentExamBusinessRules.StudentExamShouldExistWhenSelected(studentExam);

            await _studentExamRepository.DeleteAsync(studentExam!);

            DeletedStudentExamResponse response = _mapper.Map<DeletedStudentExamResponse>(studentExam);
            return response;
        }
    }
}