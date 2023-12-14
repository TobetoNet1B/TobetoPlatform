using Application.Features.Blogs.Commands.Create;
using Application.Features.Blogs.Commands.Delete;
using Application.Features.Blogs.Commands.Update;
using Application.Features.Blogs.Queries.GetById;
using Application.Features.Blogs.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Blogs.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Blog, CreateBlogCommand>().ReverseMap();
        CreateMap<Blog, CreatedBlogResponse>().ReverseMap();
        CreateMap<Blog, UpdateBlogCommand>().ReverseMap();
        CreateMap<Blog, UpdatedBlogResponse>().ReverseMap();
        CreateMap<Blog, DeleteBlogCommand>().ReverseMap();
        CreateMap<Blog, DeletedBlogResponse>().ReverseMap();
        CreateMap<Blog, GetByIdBlogResponse>().ReverseMap();
        CreateMap<Blog, GetListBlogListItemDto>().ReverseMap();
        CreateMap<IPaginate<Blog>, GetListResponse<GetListBlogListItemDto>>().ReverseMap();
    }
}