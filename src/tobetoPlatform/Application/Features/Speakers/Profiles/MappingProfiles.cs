using Application.Features.Speakers.Commands.Create;
using Application.Features.Speakers.Commands.Delete;
using Application.Features.Speakers.Commands.Update;
using Application.Features.Speakers.Queries.GetById;
using Application.Features.Speakers.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Speakers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Speaker, CreateSpeakerCommand>().ReverseMap();
        CreateMap<Speaker, CreatedSpeakerResponse>().ReverseMap();
        CreateMap<Speaker, UpdateSpeakerCommand>().ReverseMap();
        CreateMap<Speaker, UpdatedSpeakerResponse>().ReverseMap();
        CreateMap<Speaker, DeleteSpeakerCommand>().ReverseMap();
        CreateMap<Speaker, DeletedSpeakerResponse>().ReverseMap();
        CreateMap<Speaker, GetByIdSpeakerResponse>().ReverseMap();
        CreateMap<Speaker, GetListSpeakerListItemDto>().ReverseMap();
        CreateMap<IPaginate<Speaker>, GetListResponse<GetListSpeakerListItemDto>>().ReverseMap();
    }
}