using Application.Features.Abilities.Commands.Create;
using Application.Features.Abilities.Commands.Delete;
using Application.Features.Abilities.Commands.Update;
using Application.Features.Abilities.Queries.GetById;
using Application.Features.Abilities.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Abilities.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Ability, CreateAbilityCommand>().ReverseMap();
        CreateMap<Ability, CreatedAbilityResponse>().ReverseMap();
        CreateMap<Ability, UpdateAbilityCommand>().ReverseMap();
        CreateMap<Ability, UpdatedAbilityResponse>().ReverseMap();
        CreateMap<Ability, DeleteAbilityCommand>().ReverseMap();
        CreateMap<Ability, DeletedAbilityResponse>().ReverseMap();
        CreateMap<Ability, GetByIdAbilityResponse>().ReverseMap();
        CreateMap<Ability, GetListAbilityListItemDto>().ReverseMap();
        CreateMap<IPaginate<Ability>, GetListResponse<GetListAbilityListItemDto>>().ReverseMap();
    }
}