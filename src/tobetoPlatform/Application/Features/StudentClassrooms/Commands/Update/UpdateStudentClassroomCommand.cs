using Application.Features.StudentClassrooms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentClassrooms.Commands.Update;

public class UpdateStudentClassroomCommand : IRequest<UpdatedStudentClassroomResponse>
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid ClassroomId { get; set; }

    public class UpdateStudentClassroomCommandHandler : IRequestHandler<UpdateStudentClassroomCommand, UpdatedStudentClassroomResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentClassroomRepository _studentClassroomRepository;
        private readonly StudentClassroomBusinessRules _studentClassroomBusinessRules;

        public UpdateStudentClassroomCommandHandler(IMapper mapper, IStudentClassroomRepository studentClassroomRepository,
                                         StudentClassroomBusinessRules studentClassroomBusinessRules)
        {
            _mapper = mapper;
            _studentClassroomRepository = studentClassroomRepository;
            _studentClassroomBusinessRules = studentClassroomBusinessRules;
        }

        public async Task<UpdatedStudentClassroomResponse> Handle(UpdateStudentClassroomCommand request, CancellationToken cancellationToken)
        {
            StudentClassroom? studentClassroom = await _studentClassroomRepository.GetAsync(predicate: sc => sc.Id == request.Id, cancellationToken: cancellationToken);
            await _studentClassroomBusinessRules.StudentClassroomShouldExistWhenSelected(studentClassroom);
            studentClassroom = _mapper.Map(request, studentClassroom);

            await _studentClassroomRepository.UpdateAsync(studentClassroom!);

            UpdatedStudentClassroomResponse response = _mapper.Map<UpdatedStudentClassroomResponse>(studentClassroom);
            return response;
        }
    }
}