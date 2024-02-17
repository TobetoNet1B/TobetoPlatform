using Application.Features.StudentModules.Commands.Create;
using Application.Features.StudentModules.Commands.Delete;
using Application.Features.StudentModules.Commands.Update;
using Application.Features.StudentModules.Queries.GetById;
using Application.Features.StudentModules.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.StudentModules.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<StudentModule, CreateStudentModuleCommand>().ReverseMap();
        CreateMap<StudentModule, CreatedStudentModuleResponse>().ReverseMap();
        CreateMap<StudentModule, UpdateStudentModuleCommand>().ReverseMap();
        CreateMap<StudentModule, UpdatedStudentModuleResponse>().ReverseMap();
        CreateMap<StudentModule, DeleteStudentModuleCommand>().ReverseMap();
        CreateMap<StudentModule, DeletedStudentModuleResponse>().ReverseMap();
        CreateMap<StudentModule, GetByIdStudentModuleResponse>().ReverseMap();
        CreateMap<StudentModule, GetListStudentModuleListItemDto>().ReverseMap();
        CreateMap<IPaginate<StudentModule>, GetListResponse<GetListStudentModuleListItemDto>>().ReverseMap();



        CreateMap<Student, StudentDto>().ReverseMap();
        CreateMap<ModuleSet, ModuleSetDto>().ReverseMap();
        CreateMap<ClassroomModule, ClassroomDto>()
       .ForMember(dest => dest.ClassroomId, opt => opt.MapFrom(src => src.Classroom.Id))
       .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Classroom.Name))
       // Di?er alanlar burada eklenebilir...
       .ForMember(dest => dest.ClassroomStartDate, opt => opt.MapFrom(src => src.ClassroomStartDate))
       .ForMember(dest => dest.Module, opt => opt.MapFrom(src => src.ModuleSet));
    }
}