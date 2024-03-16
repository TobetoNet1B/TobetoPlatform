using Application.Features.TobetoContacts.Commands.Create;
using Application.Features.TobetoContacts.Commands.Delete;
using Application.Features.TobetoContacts.Commands.Update;
using Application.Features.TobetoContacts.Queries.GetById;
using Application.Features.TobetoContacts.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.TobetoContacts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<TobetoContact, CreateTobetoContactCommand>().ReverseMap();
        CreateMap<TobetoContact, CreatedTobetoContactResponse>().ReverseMap();
        CreateMap<TobetoContact, UpdateTobetoContactCommand>().ReverseMap();
        CreateMap<TobetoContact, UpdatedTobetoContactResponse>().ReverseMap();
        CreateMap<TobetoContact, DeleteTobetoContactCommand>().ReverseMap();
        CreateMap<TobetoContact, DeletedTobetoContactResponse>().ReverseMap();
        CreateMap<TobetoContact, GetByIdTobetoContactResponse>().ReverseMap();
        CreateMap<TobetoContact, GetListTobetoContactListItemDto>().ReverseMap();
        CreateMap<IPaginate<TobetoContact>, GetListResponse<GetListTobetoContactListItemDto>>().ReverseMap();
    }
}