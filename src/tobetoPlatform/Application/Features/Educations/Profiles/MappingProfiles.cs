using Application.Features.Educations.Commands.Create;
using Application.Features.Educations.Commands.Delete;
using Application.Features.Educations.Commands.Update;
using Application.Features.Educations.Queries.GetById;
using Application.Features.Educations.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Educations.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Education, CreateEducationCommand>().ReverseMap();
        CreateMap<Education, CreatedEducationResponse>().ReverseMap();
        CreateMap<Education, UpdateEducationCommand>().ReverseMap();
        CreateMap<Education, UpdatedEducationResponse>().ReverseMap();
        CreateMap<Education, DeleteEducationCommand>().ReverseMap();
        CreateMap<Education, DeletedEducationResponse>().ReverseMap();
        CreateMap<Education, GetByIdEducationResponse>().ReverseMap();
        CreateMap<Education, GetListEducationListItemDto>().ReverseMap();
        CreateMap<IPaginate<Education>, GetListResponse<GetListEducationListItemDto>>().ReverseMap();
    }
}