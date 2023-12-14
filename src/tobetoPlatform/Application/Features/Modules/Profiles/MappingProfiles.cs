using Application.Features.Modules.Commands.Create;
using Application.Features.Modules.Commands.Delete;
using Application.Features.Modules.Commands.Update;
using Application.Features.Modules.Queries.GetById;
using Application.Features.Modules.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Modules.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Module, CreateModuleCommand>().ReverseMap();
        CreateMap<Module, CreatedModuleResponse>().ReverseMap();
        CreateMap<Module, UpdateModuleCommand>().ReverseMap();
        CreateMap<Module, UpdatedModuleResponse>().ReverseMap();
        CreateMap<Module, DeleteModuleCommand>().ReverseMap();
        CreateMap<Module, DeletedModuleResponse>().ReverseMap();
        CreateMap<Module, GetByIdModuleResponse>().ReverseMap();
        CreateMap<Module, GetListModuleListItemDto>().ReverseMap();
        CreateMap<IPaginate<Module>, GetListResponse<GetListModuleListItemDto>>().ReverseMap();
    }
}