using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.CourseStudents.Queries.GetList;

public class GetListCourseStudentQuery : IRequest<GetListResponse<GetListCourseStudentListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListCourseStudentQueryHandler : IRequestHandler<GetListCourseStudentQuery, GetListResponse<GetListCourseStudentListItemDto>>
    {
        private readonly ICourseStudentRepository _courseStudentRepository;
        private readonly IMapper _mapper;

        public GetListCourseStudentQueryHandler(ICourseStudentRepository courseStudentRepository, IMapper mapper)
        {
            _courseStudentRepository = courseStudentRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCourseStudentListItemDto>> Handle(GetListCourseStudentQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CourseStudent> courseStudents = await _courseStudentRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCourseStudentListItemDto> response = _mapper.Map<GetListResponse<GetListCourseStudentListItemDto>>(courseStudents);
            return response;
        }
    }
}