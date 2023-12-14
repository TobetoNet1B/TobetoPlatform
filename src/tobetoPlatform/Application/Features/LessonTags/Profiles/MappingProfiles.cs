using Application.Features.LessonTags.Commands.Create;
using Application.Features.LessonTags.Commands.Delete;
using Application.Features.LessonTags.Commands.Update;
using Application.Features.LessonTags.Queries.GetById;
using Application.Features.LessonTags.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.LessonTags.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<LessonTag, CreateLessonTagCommand>().ReverseMap();
        CreateMap<LessonTag, CreatedLessonTagResponse>().ReverseMap();
        CreateMap<LessonTag, UpdateLessonTagCommand>().ReverseMap();
        CreateMap<LessonTag, UpdatedLessonTagResponse>().ReverseMap();
        CreateMap<LessonTag, DeleteLessonTagCommand>().ReverseMap();
        CreateMap<LessonTag, DeletedLessonTagResponse>().ReverseMap();
        CreateMap<LessonTag, GetByIdLessonTagResponse>().ReverseMap();
        CreateMap<LessonTag, GetListLessonTagListItemDto>().ReverseMap();
        CreateMap<IPaginate<LessonTag>, GetListResponse<GetListLessonTagListItemDto>>().ReverseMap();
    }
}