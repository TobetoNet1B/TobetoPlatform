using Application.Features.StudentClassrooms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentClassrooms.Queries.GetById;

public class GetByIdStudentClassroomQuery : IRequest<GetByIdStudentClassroomResponse>
{
    public Guid Id { get; set; }

    public class GetByIdStudentClassroomQueryHandler : IRequestHandler<GetByIdStudentClassroomQuery, GetByIdStudentClassroomResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentClassroomRepository _studentClassroomRepository;
        private readonly StudentClassroomBusinessRules _studentClassroomBusinessRules;

        public GetByIdStudentClassroomQueryHandler(IMapper mapper, IStudentClassroomRepository studentClassroomRepository, StudentClassroomBusinessRules studentClassroomBusinessRules)
        {
            _mapper = mapper;
            _studentClassroomRepository = studentClassroomRepository;
            _studentClassroomBusinessRules = studentClassroomBusinessRules;
        }

        public async Task<GetByIdStudentClassroomResponse> Handle(GetByIdStudentClassroomQuery request, CancellationToken cancellationToken)
        {
            StudentClassroom? studentClassroom = await _studentClassroomRepository.GetAsync(predicate: sc => sc.Id == request.Id, cancellationToken: cancellationToken);
            await _studentClassroomBusinessRules.StudentClassroomShouldExistWhenSelected(studentClassroom);

            GetByIdStudentClassroomResponse response = _mapper.Map<GetByIdStudentClassroomResponse>(studentClassroom);
            return response;
        }
    }
}