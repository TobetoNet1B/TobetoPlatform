using Application.Features.StudentClassrooms.Rules;
using Application.Features.StudentModules.Queries.GetById;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
            IPaginate<StudentClassroom> studentClassroom = await _studentClassroomRepository.GetListAsync(
       predicate: sc => sc.StudentId == request.Id,
       include: m => m.Include(s => s.Student)
                     .Include(s => s.Classroom).ThenInclude(c => c.ClassroomModules).ThenInclude(cm => cm.ModuleSet).ThenInclude(cm => cm.Company),
       cancellationToken: cancellationToken);

            // Öğrenci ve sınıf bilgilerini doldur
            GetByIdStudentClassroomResponse response = new GetByIdStudentClassroomResponse
            {
                Student = _mapper.Map<StudentDto>(studentClassroom.Items.FirstOrDefault()?.Student),
                Classroom = _mapper.Map<ClassroomDto>(studentClassroom.Items.FirstOrDefault()?.Classroom),
                ModuleSets = studentClassroom.Items.SelectMany(sc => sc.Classroom.ClassroomModules.Select(cm => _mapper.Map<ModuleSetDto>(cm.ModuleSet))).ToList()
            };

            return response;
        }
    }
}