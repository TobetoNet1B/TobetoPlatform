using Application.Features.CourseStudents.Commands.Create;
using Application.Features.CourseStudents.Commands.Delete;
using Application.Features.CourseStudents.Commands.Update;
using Application.Features.CourseStudents.Queries.GetById;
using Application.Features.CourseStudents.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CourseStudents.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CourseStudent, CreateCourseStudentCommand>().ReverseMap();
        CreateMap<CourseStudent, CreatedCourseStudentResponse>().ReverseMap();
        CreateMap<CourseStudent, UpdateCourseStudentCommand>().ReverseMap();
        CreateMap<CourseStudent, UpdatedCourseStudentResponse>().ReverseMap();
        CreateMap<CourseStudent, DeleteCourseStudentCommand>().ReverseMap();
        CreateMap<CourseStudent, DeletedCourseStudentResponse>().ReverseMap();
        CreateMap<CourseStudent, GetByIdCourseStudentResponse>().ReverseMap();
        CreateMap<CourseStudent, GetListCourseStudentListItemDto>().ReverseMap();
        CreateMap<IPaginate<CourseStudent>, GetListResponse<GetListCourseStudentListItemDto>>().ReverseMap();
    }
}