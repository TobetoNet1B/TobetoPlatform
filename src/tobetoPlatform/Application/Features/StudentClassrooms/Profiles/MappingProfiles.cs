using Application.Features.StudentClassrooms.Commands.Create;
using Application.Features.StudentClassrooms.Commands.Delete;
using Application.Features.StudentClassrooms.Commands.Update;
using Application.Features.StudentClassrooms.Queries.GetById;
using Application.Features.StudentClassrooms.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Features.StudentClassrooms.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<StudentClassroom, CreateStudentClassroomCommand>().ReverseMap();
        CreateMap<StudentClassroom, CreatedStudentClassroomResponse>().ReverseMap();
        CreateMap<StudentClassroom, UpdateStudentClassroomCommand>().ReverseMap();
        CreateMap<StudentClassroom, UpdatedStudentClassroomResponse>().ReverseMap();
        CreateMap<StudentClassroom, DeleteStudentClassroomCommand>().ReverseMap();
        CreateMap<StudentClassroom, DeletedStudentClassroomResponse>().ReverseMap();
        CreateMap<StudentClassroom, GetByIdStudentClassroomResponse>().ReverseMap();
        CreateMap<StudentClassroom, GetListStudentClassroomListItemDto>().ReverseMap();
        CreateMap<IPaginate<StudentClassroom>, GetListResponse<GetListStudentClassroomListItemDto>>().ReverseMap();

        CreateMap<Student, StudentDto>().ReverseMap();
        CreateMap<Classroom, ClassroomDto>()
      .ForMember(dest => dest.ClassroomId, opt => opt.MapFrom(src => src.Id))
      
      .ReverseMap();
        CreateMap<Classroom, ClassrromGetDto>()
   .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ReverseMap();

        CreateMap<User, UserDto>()
    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email)).ReverseMap();
        CreateMap<ModuleSet, ModuleSetDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.ClassroomStartDate, opt => opt.MapFrom(src => src.ClassroomModules.FirstOrDefault().ClassroomStartDate))
            .ReverseMap();
    }
}