using Application.Features.CategoryOfCourses.Commands.Create;
using Application.Features.CategoryOfCourses.Commands.Delete;
using Application.Features.CategoryOfCourses.Commands.Update;
using Application.Features.CategoryOfCourses.Queries.GetById;
using Application.Features.CategoryOfCourses.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CategoryOfCourses.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CategoryOfCourse, CreateCategoryOfCourseCommand>().ReverseMap();
        CreateMap<CategoryOfCourse, CreatedCategoryOfCourseResponse>().ReverseMap();
        CreateMap<CategoryOfCourse, UpdateCategoryOfCourseCommand>().ReverseMap();
        CreateMap<CategoryOfCourse, UpdatedCategoryOfCourseResponse>().ReverseMap();
        CreateMap<CategoryOfCourse, DeleteCategoryOfCourseCommand>().ReverseMap();
        CreateMap<CategoryOfCourse, DeletedCategoryOfCourseResponse>().ReverseMap();
        CreateMap<CategoryOfCourse, GetByIdCategoryOfCourseResponse>().ReverseMap();
        CreateMap<CategoryOfCourse, GetListCategoryOfCourseListItemDto>().ReverseMap();
        CreateMap<IPaginate<CategoryOfCourse>, GetListResponse<GetListCategoryOfCourseListItemDto>>().ReverseMap();
    }
}