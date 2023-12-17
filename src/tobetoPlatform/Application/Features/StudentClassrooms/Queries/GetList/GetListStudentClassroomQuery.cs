using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

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
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListStudentClassroomListItemDto> response = _mapper.Map<GetListResponse<GetListStudentClassroomListItemDto>>(studentClassrooms);
            return response;
        }
    }
}