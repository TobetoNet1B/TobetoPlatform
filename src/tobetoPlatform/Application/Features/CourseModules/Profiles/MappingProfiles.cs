using Application.Features.CourseModules.Commands.Create;
using Application.Features.CourseModules.Commands.Delete;
using Application.Features.CourseModules.Commands.Update;
using Application.Features.CourseModules.Queries.GetById;
using Application.Features.CourseModules.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CourseModules.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CourseModule, CreateCourseModuleCommand>().ReverseMap();
        CreateMap<CourseModule, CreatedCourseModuleResponse>().ReverseMap();
        CreateMap<CourseModule, UpdateCourseModuleCommand>().ReverseMap();
        CreateMap<CourseModule, UpdatedCourseModuleResponse>().ReverseMap();
        CreateMap<CourseModule, DeleteCourseModuleCommand>().ReverseMap();
        CreateMap<CourseModule, DeletedCourseModuleResponse>().ReverseMap();
        CreateMap<CourseModule, GetByIdCourseModuleResponse>().ReverseMap();
        CreateMap<CourseModule, GetListCourseModuleListItemDto>().ReverseMap();
        CreateMap<IPaginate<CourseModule>, GetListResponse<GetListCourseModuleListItemDto>>().ReverseMap();
    }
}