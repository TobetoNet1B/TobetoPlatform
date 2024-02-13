using Application.Features.ClassroomModules.Commands.Create;
using Application.Features.ClassroomModules.Commands.Delete;
using Application.Features.ClassroomModules.Commands.Update;
using Application.Features.ClassroomModules.Queries.GetById;
using Application.Features.ClassroomModules.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ClassroomModules.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ClassroomModule, CreateClassroomModuleCommand>().ReverseMap();
        CreateMap<ClassroomModule, CreatedClassroomModuleResponse>().ReverseMap();
        CreateMap<ClassroomModule, UpdateClassroomModuleCommand>().ReverseMap();
        CreateMap<ClassroomModule, UpdatedClassroomModuleResponse>().ReverseMap();
        CreateMap<ClassroomModule, DeleteClassroomModuleCommand>().ReverseMap();
        CreateMap<ClassroomModule, DeletedClassroomModuleResponse>().ReverseMap();
        CreateMap<ClassroomModule, GetByIdClassroomModuleResponse>().ReverseMap();
        CreateMap<ClassroomModule, GetListClassroomModuleListItemDto>().ReverseMap();
        CreateMap<IPaginate<ClassroomModule>, GetListResponse<GetListClassroomModuleListItemDto>>().ReverseMap();
    }
}