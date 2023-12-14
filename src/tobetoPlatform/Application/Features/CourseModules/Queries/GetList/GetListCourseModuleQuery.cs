using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.CourseModules.Queries.GetList;

public class GetListCourseModuleQuery : IRequest<GetListResponse<GetListCourseModuleListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListCourseModuleQueryHandler : IRequestHandler<GetListCourseModuleQuery, GetListResponse<GetListCourseModuleListItemDto>>
    {
        private readonly ICourseModuleRepository _courseModuleRepository;
        private readonly IMapper _mapper;

        public GetListCourseModuleQueryHandler(ICourseModuleRepository courseModuleRepository, IMapper mapper)
        {
            _courseModuleRepository = courseModuleRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCourseModuleListItemDto>> Handle(GetListCourseModuleQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CourseModule> courseModules = await _courseModuleRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCourseModuleListItemDto> response = _mapper.Map<GetListResponse<GetListCourseModuleListItemDto>>(courseModules);
            return response;
        }
    }
}