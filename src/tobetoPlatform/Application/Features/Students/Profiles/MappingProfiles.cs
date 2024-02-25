using Application.Features.Students.Commands.Create;
using Application.Features.Students.Commands.Delete;
using Application.Features.Students.Commands.Update;
using Application.Features.Students.Queries.GetById;
using Application.Features.Students.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Services.UsersService;
using Core.Security.Entities;

namespace Application.Features.Students.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Student, CreateStudentCommand>().ReverseMap();
        CreateMap<Student, CreatedStudentResponse>().ReverseMap();
        CreateMap<Student, UpdateStudentCommand>().ReverseMap();
        CreateMap<Student, UpdatedStudentResponse>().ReverseMap();
        CreateMap<Student, DeleteStudentCommand>().ReverseMap();
        CreateMap<Student, DeletedStudentResponse>().ReverseMap();
        CreateMap<Student, GetByIdStudentResponse>().ReverseMap();
        CreateMap<Student, GetListStudentListItemDto>().ReverseMap();
        CreateMap<IPaginate<Student>, GetListResponse<GetListStudentListItemDto>>().ReverseMap();

        CreateMap<UserAddDto, CreateStudentCommand>().ReverseMap();
        CreateMap<User, UserDto>();
        CreateMap<StudentExam, StudentExamDto>();
        CreateMap<Experience, ExperiencesDto>();
        CreateMap<StudentForeignLanguage, StudentForeignLanguagesDto>()
            .ForMember(dest => dest.LanguageName, opt => opt.MapFrom(src => src.ForeignLanguage.Name))
            .ForMember(dest => dest.LanguageLevel, opt => opt.MapFrom(src => src.ForeignLanguageLevel.Name));
        CreateMap<StudentClassroom, StudentClassroomsDto>()
            .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.Student.User.FirstName))
            .ForMember(dest => dest.ClassName, opt => opt.MapFrom(src => src.Classroom.Name))
            .ForMember(dest => dest.ClassSize, opt => opt.MapFrom(src => src.Classroom.ClassSize));
        CreateMap<StudentSocialMedia, SocialMediasDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.SocialMedia.Name))
            .ForMember(dest => dest.Icon, opt => opt.MapFrom(src => src.SocialMedia.IconUrl));
        CreateMap<Education, EducationsDto>();
        CreateMap<Certificate, CertificatesDto>();
        CreateMap<Ability, AbilitiesDto>();
    }
}