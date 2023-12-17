using Application.Features.StudentClassrooms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentClassrooms.Commands.Create;

public class CreateStudentClassroomCommand : IRequest<CreatedStudentClassroomResponse>
{
    public Guid StudentId { get; set; }
    public Guid ClassroomId { get; set; }

    public class CreateStudentClassroomCommandHandler : IRequestHandler<CreateStudentClassroomCommand, CreatedStudentClassroomResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentClassroomRepository _studentClassroomRepository;
        private readonly StudentClassroomBusinessRules _studentClassroomBusinessRules;

        public CreateStudentClassroomCommandHandler(IMapper mapper, IStudentClassroomRepository studentClassroomRepository,
                                         StudentClassroomBusinessRules studentClassroomBusinessRules)
        {
            _mapper = mapper;
            _studentClassroomRepository = studentClassroomRepository;
            _studentClassroomBusinessRules = studentClassroomBusinessRules;
        }

        public async Task<CreatedStudentClassroomResponse> Handle(CreateStudentClassroomCommand request, CancellationToken cancellationToken)
        {
            StudentClassroom studentClassroom = _mapper.Map<StudentClassroom>(request);

            await _studentClassroomRepository.AddAsync(studentClassroom);

            CreatedStudentClassroomResponse response = _mapper.Map<CreatedStudentClassroomResponse>(studentClassroom);
            return response;
        }
    }
}