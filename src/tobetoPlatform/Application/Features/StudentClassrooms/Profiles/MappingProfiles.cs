using Application.Features.StudentClassrooms.Commands.Create;
using Application.Features.StudentClassrooms.Commands.Delete;
using Application.Features.StudentClassrooms.Commands.Update;
using Application.Features.StudentClassrooms.Queries.GetById;
using Application.Features.StudentClassrooms.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.StudentClassrooms.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<StudentClassroom, CreateStudentClassroomCommand>().ReverseMap();
        CreateMap<StudentClassroom, CreatedStudentClassroomResponse>().ReverseMap();
        CreateMap<StudentClassroom, UpdateStudentClassroomCommand>().ReverseMap();
        CreateMap<StudentClassroom, UpdatedStudentClassroomResponse>().ReverseMap();
        CreateMap<StudentClassroom, DeleteStudentClassroomCommand>().ReverseMap();
        CreateMap<StudentClassroom, DeletedStudentClassroomResponse>().ReverseMap();
        CreateMap<StudentClassroom, GetByIdStudentClassroomResponse>().ReverseMap();
        CreateMap<StudentClassroom, GetListStudentClassroomListItemDto>().ReverseMap();
        CreateMap<IPaginate<StudentClassroom>, GetListResponse<GetListStudentClassroomListItemDto>>().ReverseMap();
    }
}