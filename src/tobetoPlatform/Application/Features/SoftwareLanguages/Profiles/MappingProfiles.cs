using Application.Features.SoftwareLanguages.Commands.Create;
using Application.Features.SoftwareLanguages.Commands.Delete;
using Application.Features.SoftwareLanguages.Commands.Update;
using Application.Features.SoftwareLanguages.Queries.GetById;
using Application.Features.SoftwareLanguages.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.SoftwareLanguages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<SoftwareLanguage, CreateSoftwareLanguageCommand>().ReverseMap();
        CreateMap<SoftwareLanguage, CreatedSoftwareLanguageResponse>().ReverseMap();
        CreateMap<SoftwareLanguage, UpdateSoftwareLanguageCommand>().ReverseMap();
        CreateMap<SoftwareLanguage, UpdatedSoftwareLanguageResponse>().ReverseMap();
        CreateMap<SoftwareLanguage, DeleteSoftwareLanguageCommand>().ReverseMap();
        CreateMap<SoftwareLanguage, DeletedSoftwareLanguageResponse>().ReverseMap();
        CreateMap<SoftwareLanguage, GetByIdSoftwareLanguageResponse>().ReverseMap();
        CreateMap<SoftwareLanguage, GetListSoftwareLanguageListItemDto>().ReverseMap();
        CreateMap<IPaginate<SoftwareLanguage>, GetListResponse<GetListSoftwareLanguageListItemDto>>().ReverseMap();
    }
}