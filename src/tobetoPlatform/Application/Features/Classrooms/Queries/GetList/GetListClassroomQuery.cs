using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Classrooms.Queries.GetList;

public class GetListClassroomQuery : IRequest<GetListResponse<GetListClassroomListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListClassroomQueryHandler : IRequestHandler<GetListClassroomQuery, GetListResponse<GetListClassroomListItemDto>>
    {
        private readonly IClassroomRepository _classroomRepository;
        private readonly IMapper _mapper;

        public GetListClassroomQueryHandler(IClassroomRepository classroomRepository, IMapper mapper)
        {
            _classroomRepository = classroomRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListClassroomListItemDto>> Handle(GetListClassroomQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Classroom> classrooms = await _classroomRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListClassroomListItemDto> response = _mapper.Map<GetListResponse<GetListClassroomListItemDto>>(classrooms);
            return response;
        }
    }
}