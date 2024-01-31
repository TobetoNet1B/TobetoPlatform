using Application.Features.Students.Queries.GetById;
using Application.Features.Students.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Students.Queries.GetByUserId;

public class GetByUserIdStudentQuery : IRequest<GetByIdStudentResponse>
{
    public int UserId { get; set; }


    public class GetByUserIdStudentQueryHandler : IRequestHandler<GetByUserIdStudentQuery, GetByIdStudentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;
        private readonly StudentBusinessRules _studentBusinessRules;

        public GetByUserIdStudentQueryHandler(IMapper mapper, IStudentRepository studentRepository, StudentBusinessRules studentBusinessRules)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
            _studentBusinessRules = studentBusinessRules;
        }

        public async Task<GetByIdStudentResponse> Handle(GetByUserIdStudentQuery request, CancellationToken cancellationToken)
        {
            Student? student = await _studentRepository.GetAsync(
             include: m => m.Include(s => s.User)
                           .Include(s => s.StudentExams)
                               .ThenInclude(se => se.Exam)
                           .Include(s => s.StudentForeignLanguages)
                               .ThenInclude(se => se.ForeignLanguage)
                           .Include(s => s.StudentForeignLanguages)
                               .ThenInclude(se => se.ForeignLanguageLevel)
                           .Include(s => s.StudentClassrooms)
                               .ThenInclude(se => se.Classroom)
                           .Include(s => s.Experiences)
                           .Include(s => s.SocialMedias)
                           .Include(s => s.Educations)
                           .Include(s => s.Certificates)
                           .Include(s => s.Abilities)

                                ,
            predicate: s => s.UserId == request.UserId,
            cancellationToken: cancellationToken);

            await _studentBusinessRules.StudentShouldExistWhenSelected(student);

            GetByIdStudentResponse response = _mapper.Map<GetByIdStudentResponse>(student);
            response.User = _mapper.Map<UserDto>(student.User);
            response.StudentExams = student.StudentExams
                                       .Select(se => _mapper.Map<StudentExamDto>(se))
                                       .ToList();

            response.Experiences = student.Experiences
                                  .Select(experience => _mapper.Map<ExperiencesDto>(experience))
                                  .ToList();

            response.StudentForeignLanguages = student.StudentForeignLanguages
                                       .Select(se => _mapper.Map<StudentForeignLanguagesDto>(se))
                                       .ToList();

            response.StudentClassrooms = student.StudentClassrooms
                                       .Select(se => _mapper.Map<StudentClassroomsDto>(se))
                                       .ToList();

            response.SocialMedias = student.SocialMedias
                                       .Select(se => _mapper.Map<SocialMediasDto>(se))
                                       .ToList();

            response.Educations = student.Educations
                                       .Select(se => _mapper.Map<EducationsDto>(se))
                                       .ToList();

            response.Abilities = student.Abilities
                                       .Select(se => _mapper.Map<AbilitiesDto>(se))
                                       .ToList();


            return response;
        }
    }
}
