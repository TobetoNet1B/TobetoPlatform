using Application.Features.StudentSocialMedias.Commands.Create;
using Application.Features.StudentSocialMedias.Commands.Delete;
using Application.Features.StudentSocialMedias.Commands.Update;
using Application.Features.StudentSocialMedias.Queries.GetById;
using Application.Features.StudentSocialMedias.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.StudentSocialMedias.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<StudentSocialMedia, CreateStudentSocialMediaCommand>().ReverseMap();
        CreateMap<StudentSocialMedia, CreatedStudentSocialMediaResponse>().ReverseMap();
        CreateMap<StudentSocialMedia, UpdateStudentSocialMediaCommand>().ReverseMap();
        CreateMap<StudentSocialMedia, UpdatedStudentSocialMediaResponse>().ReverseMap();
        CreateMap<StudentSocialMedia, DeleteStudentSocialMediaCommand>().ReverseMap();
        CreateMap<StudentSocialMedia, DeletedStudentSocialMediaResponse>().ReverseMap();
        CreateMap<StudentSocialMedia, GetByIdStudentSocialMediaResponse>().ReverseMap();
        CreateMap<StudentSocialMedia, GetListStudentSocialMediaListItemDto>().ReverseMap();
        CreateMap<IPaginate<StudentSocialMedia>, GetListResponse<GetListStudentSocialMediaListItemDto>>().ReverseMap();

        CreateMap<SocialMedia, SocialMediaDto>()
            .ForMember(desc => desc.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(desc => desc.IconUrl, opt => opt.MapFrom(src => src.IconUrl))
              .ForMember(dest => dest.SocialMediaUrl, opt => opt.MapFrom(src => src.StudentSocialMedias.FirstOrDefault().SocialMediaUrl))
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.StudentSocialMedias.FirstOrDefault().Id))
            .ReverseMap();
        ;
    }
}