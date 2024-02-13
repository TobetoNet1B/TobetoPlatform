using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.ClassroomModules.Queries.GetList;

public class GetListClassroomModuleQuery : IRequest<GetListResponse<GetListClassroomModuleListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListClassroomModuleQueryHandler : IRequestHandler<GetListClassroomModuleQuery, GetListResponse<GetListClassroomModuleListItemDto>>
    {
        private readonly IClassroomModuleRepository _classroomModuleRepository;
        private readonly IMapper _mapper;

        public GetListClassroomModuleQueryHandler(IClassroomModuleRepository classroomModuleRepository, IMapper mapper)
        {
            _classroomModuleRepository = classroomModuleRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListClassroomModuleListItemDto>> Handle(GetListClassroomModuleQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ClassroomModule> classroomModules = await _classroomModuleRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListClassroomModuleListItemDto> response = _mapper.Map<GetListResponse<GetListClassroomModuleListItemDto>>(classroomModules);
            return response;
        }
    }
}