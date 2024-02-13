using Application.Features.ModuleSetCategories.Commands.Create;
using Application.Features.ModuleSetCategories.Commands.Delete;
using Application.Features.ModuleSetCategories.Commands.Update;
using Application.Features.ModuleSetCategories.Queries.GetById;
using Application.Features.ModuleSetCategories.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ModuleSetCategories.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ModuleSetCategory, CreateModuleSetCategoryCommand>().ReverseMap();
        CreateMap<ModuleSetCategory, CreatedModuleSetCategoryResponse>().ReverseMap();
        CreateMap<ModuleSetCategory, UpdateModuleSetCategoryCommand>().ReverseMap();
        CreateMap<ModuleSetCategory, UpdatedModuleSetCategoryResponse>().ReverseMap();
        CreateMap<ModuleSetCategory, DeleteModuleSetCategoryCommand>().ReverseMap();
        CreateMap<ModuleSetCategory, DeletedModuleSetCategoryResponse>().ReverseMap();
        CreateMap<ModuleSetCategory, GetByIdModuleSetCategoryResponse>().ReverseMap();
        CreateMap<ModuleSetCategory, GetListModuleSetCategoryListItemDto>().ReverseMap();
        CreateMap<IPaginate<ModuleSetCategory>, GetListResponse<GetListModuleSetCategoryListItemDto>>().ReverseMap();
    }
}