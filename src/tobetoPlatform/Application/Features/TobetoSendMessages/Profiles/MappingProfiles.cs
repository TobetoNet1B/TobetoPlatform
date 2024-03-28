using Application.Features.TobetoSendMessages.Commands.Create;
using Application.Features.TobetoSendMessages.Commands.Delete;
using Application.Features.TobetoSendMessages.Commands.Update;
using Application.Features.TobetoSendMessages.Queries.GetById;
using Application.Features.TobetoSendMessages.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.TobetoSendMessages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<TobetoSendMessage, CreateTobetoSendMessageCommand>().ReverseMap();
        CreateMap<TobetoSendMessage, CreatedTobetoSendMessageResponse>().ReverseMap();
        CreateMap<TobetoSendMessage, UpdateTobetoSendMessageCommand>().ReverseMap();
        CreateMap<TobetoSendMessage, UpdatedTobetoSendMessageResponse>().ReverseMap();
        CreateMap<TobetoSendMessage, DeleteTobetoSendMessageCommand>().ReverseMap();
        CreateMap<TobetoSendMessage, DeletedTobetoSendMessageResponse>().ReverseMap();
        CreateMap<TobetoSendMessage, GetByIdTobetoSendMessageResponse>().ReverseMap();
        CreateMap<TobetoSendMessage, GetListTobetoSendMessageListItemDto>().ReverseMap();
        CreateMap<IPaginate<TobetoSendMessage>, GetListResponse<GetListTobetoSendMessageListItemDto>>().ReverseMap();
    }
}