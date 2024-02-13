using Application.Features.ModuleTypes.Commands.Create;
using Application.Features.ModuleTypes.Commands.Delete;
using Application.Features.ModuleTypes.Commands.Update;
using Application.Features.ModuleTypes.Queries.GetById;
using Application.Features.ModuleTypes.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ModuleTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ModuleType, CreateModuleTypeCommand>().ReverseMap();
        CreateMap<ModuleType, CreatedModuleTypeResponse>().ReverseMap();
        CreateMap<ModuleType, UpdateModuleTypeCommand>().ReverseMap();
        CreateMap<ModuleType, UpdatedModuleTypeResponse>().ReverseMap();
        CreateMap<ModuleType, DeleteModuleTypeCommand>().ReverseMap();
        CreateMap<ModuleType, DeletedModuleTypeResponse>().ReverseMap();
        CreateMap<ModuleType, GetByIdModuleTypeResponse>().ReverseMap();
        CreateMap<ModuleType, GetListModuleTypeListItemDto>().ReverseMap();
        CreateMap<IPaginate<ModuleType>, GetListResponse<GetListModuleTypeListItemDto>>().ReverseMap();
    }
}