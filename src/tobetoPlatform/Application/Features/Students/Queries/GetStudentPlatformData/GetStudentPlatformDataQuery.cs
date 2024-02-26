using Application.Features.Students.Queries.GetById;
using Application.Features.Students.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Application.Features.Students.Queries.GetStudentPlatformData;
public class GetStudentPlatformDataQuery : IRequest<GetStudentPlatformDataResponse>
{
    public int UserId { get; set; }

    public class GetStudentPlatformDataQueryHandler : IRequestHandler<GetStudentPlatformDataQuery, GetStudentPlatformDataResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;
        private readonly StudentBusinessRules _studentBusinessRules;

        public GetStudentPlatformDataQueryHandler(IMapper mapper, IStudentRepository studentRepository, StudentBusinessRules studentBusinessRules)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
            _studentBusinessRules = studentBusinessRules;
        }

        public async Task<GetStudentPlatformDataResponse> Handle(GetStudentPlatformDataQuery request, CancellationToken cancellationToken)
        {
            Student? student = await _studentRepository.GetAsync(
                        include: m => m.Include(s => s.User)
                                      .Include(s => s.StudentExams)
                                          .ThenInclude(se => se.Exam)
                                      .Include(s => s.StudentAppeals)
                                          .ThenInclude(se => se.Appeal)
                                      .Include(s => s.StudentClassrooms)
                                          .ThenInclude(se => se.Classroom)
                                          .ThenInclude(se => se.ClassroomModules)
                                      .Include(s => s.Surveys),
                                     

                       predicate: s => s.UserId == request.UserId,
                       cancellationToken: cancellationToken);

            await _studentBusinessRules.StudentShouldExistWhenSelected(student);

            GetStudentPlatformDataResponse response = _mapper.Map<GetStudentPlatformDataResponse>(student);
            //response.User = _mapper.Map<UserDto>(student.User);
            //response.StudentExams = student.StudentExams
            //                           .Select(se => _mapper.Map<ExamDto>(se))
            //                           .ToList();

            //response.StudentAppeals = student.StudentAppeals
            //                      .Select(experience => _mapper.Map<StudentAppealDto>(experience))
            //                      .ToList();

            //response.StudentClassrooms = student.StudentClassrooms
            //                           .Select(se => _mapper.Map<StudentClassroomsDto>(se))
            //                           .ToList();

            //response.Surveys = student.Surveys
            //                           .Select(se => _mapper.Map<SurveyDto>(se))
            //                           .ToList();

            //response.Educations = student.Educations
            //                           .Select(se => _mapper.Map<EducationsDto>(se))
            //                           .ToList();

            //response.Abilities = student.Abilities
            //                           .Select(se => _mapper.Map<AbilitiesDto>(se))
            //                           .ToList();


            return response;
        }
    }
}