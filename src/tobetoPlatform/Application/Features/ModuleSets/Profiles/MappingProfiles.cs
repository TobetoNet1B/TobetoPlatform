using Application.Features.ModuleSets.Commands.Create;
using Application.Features.ModuleSets.Commands.Delete;
using Application.Features.ModuleSets.Commands.Update;
using Application.Features.ModuleSets.Queries.GetById;
using Application.Features.ModuleSets.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.ModuleSets.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ModuleSet, CreateModuleSetCommand>().ReverseMap();
        CreateMap<ModuleSet, CreatedModuleSetResponse>().ReverseMap();
        CreateMap<ModuleSet, UpdateModuleSetCommand>().ReverseMap();
        CreateMap<ModuleSet, UpdatedModuleSetResponse>().ReverseMap();
        CreateMap<ModuleSet, DeleteModuleSetCommand>().ReverseMap();
        CreateMap<ModuleSet, DeletedModuleSetResponse>().ReverseMap();
        CreateMap<ModuleSet, GetByIdModuleSetResponse>().ReverseMap();
        CreateMap<ModuleSet, GetListModuleSetListItemDto>().ReverseMap();
        CreateMap<IPaginate<ModuleSet>, GetListResponse<GetListModuleSetListItemDto>>().ReverseMap();


        CreateMap<Company, CompanyDto>().ReverseMap();
        CreateMap<CourseModule, CourseModuleDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Course.Name));
        //.ForMember(dest => dest.Lessons, opt => opt.MapFrom(src => src.Course.Lessons));
        CreateMap<StudentModule, StudentModuleDto>().ReverseMap();
        CreateMap<ModuleSetCategory, ModuleSetCategoryDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CategoryOfModuleSet.Name));
    }
}