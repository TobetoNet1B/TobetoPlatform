using Application.Features.StudentClassrooms.Constants;
using Application.Features.StudentClassrooms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentClassrooms.Commands.Delete;

public class DeleteStudentClassroomCommand : IRequest<DeletedStudentClassroomResponse>
{
    public Guid Id { get; set; }

    public class DeleteStudentClassroomCommandHandler : IRequestHandler<DeleteStudentClassroomCommand, DeletedStudentClassroomResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentClassroomRepository _studentClassroomRepository;
        private readonly StudentClassroomBusinessRules _studentClassroomBusinessRules;

        public DeleteStudentClassroomCommandHandler(IMapper mapper, IStudentClassroomRepository studentClassroomRepository,
                                         StudentClassroomBusinessRules studentClassroomBusinessRules)
        {
            _mapper = mapper;
            _studentClassroomRepository = studentClassroomRepository;
            _studentClassroomBusinessRules = studentClassroomBusinessRules;
        }

        public async Task<DeletedStudentClassroomResponse> Handle(DeleteStudentClassroomCommand request, CancellationToken cancellationToken)
        {
            StudentClassroom? studentClassroom = await _studentClassroomRepository.GetAsync(predicate: sc => sc.Id == request.Id, cancellationToken: cancellationToken);
            await _studentClassroomBusinessRules.StudentClassroomShouldExistWhenSelected(studentClassroom);

            await _studentClassroomRepository.DeleteAsync(studentClassroom!);

            DeletedStudentClassroomResponse response = _mapper.Map<DeletedStudentClassroomResponse>(studentClassroom);
            return response;
        }
    }
}