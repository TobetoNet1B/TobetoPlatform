using Application.Features.CategoryOfModuleSets.Commands.Create;
using Application.Features.CategoryOfModuleSets.Commands.Delete;
using Application.Features.CategoryOfModuleSets.Commands.Update;
using Application.Features.CategoryOfModuleSets.Queries.GetById;
using Application.Features.CategoryOfModuleSets.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CategoryOfModuleSets.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CategoryOfModuleSet, CreateCategoryOfModuleSetCommand>().ReverseMap();
        CreateMap<CategoryOfModuleSet, CreatedCategoryOfModuleSetResponse>().ReverseMap();
        CreateMap<CategoryOfModuleSet, UpdateCategoryOfModuleSetCommand>().ReverseMap();
        CreateMap<CategoryOfModuleSet, UpdatedCategoryOfModuleSetResponse>().ReverseMap();
        CreateMap<CategoryOfModuleSet, DeleteCategoryOfModuleSetCommand>().ReverseMap();
        CreateMap<CategoryOfModuleSet, DeletedCategoryOfModuleSetResponse>().ReverseMap();
        CreateMap<CategoryOfModuleSet, GetByIdCategoryOfModuleSetResponse>().ReverseMap();
        CreateMap<CategoryOfModuleSet, GetListCategoryOfModuleSetListItemDto>().ReverseMap();
        CreateMap<IPaginate<CategoryOfModuleSet>, GetListResponse<GetListCategoryOfModuleSetListItemDto>>().ReverseMap();
    }
}