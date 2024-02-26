using Application.Features.StudentForeignLanguages.Commands.Create;
using Application.Features.StudentForeignLanguages.Commands.Delete;
using Application.Features.StudentForeignLanguages.Commands.Update;
using Application.Features.StudentForeignLanguages.Queries.GetById;
using Application.Features.StudentForeignLanguages.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;
using Application.Features.StudentSocialMedias.Queries.GetById;

namespace Application.Features.StudentForeignLanguages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<StudentForeignLanguage, CreateStudentForeignLanguageCommand>().ReverseMap();
        CreateMap<StudentForeignLanguage, CreatedStudentForeignLanguageResponse>().ReverseMap();
        CreateMap<StudentForeignLanguage, UpdateStudentForeignLanguageCommand>().ReverseMap();
        CreateMap<StudentForeignLanguage, UpdatedStudentForeignLanguageResponse>().ReverseMap();
        CreateMap<StudentForeignLanguage, DeleteStudentForeignLanguageCommand>().ReverseMap();
        CreateMap<StudentForeignLanguage, DeletedStudentForeignLanguageResponse>().ReverseMap();
        CreateMap<StudentForeignLanguage, GetByIdStudentForeignLanguageResponse>().ReverseMap();
        CreateMap<StudentForeignLanguage, GetListStudentForeignLanguageListItemDto>().ReverseMap();
        CreateMap<IPaginate<StudentForeignLanguage>, GetListResponse<GetListStudentForeignLanguageListItemDto>>().ReverseMap();

        CreateMap<ForeignLanguage, ForeignLanguageDto>()
           .ForMember(desc => desc.Name, opt => opt.MapFrom(src => src.Name))
           .ReverseMap();
        ;
        CreateMap<ForeignLanguageLevel, ForeignLanguageLevelDto>()
         .ForMember(desc => desc.Name, opt => opt.MapFrom(src => src.Name))
         .ReverseMap();
        ;
    }
}