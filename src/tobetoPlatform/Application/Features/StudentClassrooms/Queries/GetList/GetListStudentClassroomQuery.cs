using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.StudentClassrooms.Queries.GetList;

public class GetListStudentClassroomQuery : IRequest<GetListResponse<GetListStudentClassroomListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListStudentClassroomQueryHandler : IRequestHandler<GetListStudentClassroomQuery, GetListResponse<GetListStudentClassroomListItemDto>>
    {
        private readonly IStudentClassroomRepository _studentClassroomRepository;
        private readonly IMapper _mapper;

        public GetListStudentClassroomQueryHandler(IStudentClassroomRepository studentClassroomRepository, IMapper mapper)
        {
            _studentClassroomRepository = studentClassroomRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListStudentClassroomListItemDto>> Handle(GetListStudentClassroomQuery request, CancellationToken cancellationToken)
        {
            IPaginate<StudentClassroom> studentClassrooms = await _studentClassroomRepository.GetListAsync(
                include: m => m.Include(s => s.Classroom)
                .Include(s => s.Student).ThenInclude(s => s.User),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
            );

         
            GetListResponse<GetListStudentClassroomListItemDto>? response = new GetListResponse<GetListStudentClassroomListItemDto>
            {
                Items = studentClassrooms.Items.Select(sc => new GetListStudentClassroomListItemDto
                {
                    Id = sc.Id,
                    StudentId = sc.StudentId,
                    ClassroomId = sc.ClassroomId,
                    Classroom = _mapper.Map<ClassrromGetDto>(sc.Classroom),
                    User = new UserDto
                    {
                        Email = sc.Student.User.Email 
                    }
                }).ToList(),
                Count = studentClassrooms.Count,
                Index = studentClassrooms.Index,
                Size = studentClassrooms.Size 
            };

            return response;
        }
    }
}