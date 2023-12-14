using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.StudentModules.Queries.GetList;

public class GetListStudentModuleQuery : IRequest<GetListResponse<GetListStudentModuleListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListStudentModuleQueryHandler : IRequestHandler<GetListStudentModuleQuery, GetListResponse<GetListStudentModuleListItemDto>>
    {
        private readonly IStudentModuleRepository _studentModuleRepository;
        private readonly IMapper _mapper;

        public GetListStudentModuleQueryHandler(IStudentModuleRepository studentModuleRepository, IMapper mapper)
        {
            _studentModuleRepository = studentModuleRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListStudentModuleListItemDto>> Handle(GetListStudentModuleQuery request, CancellationToken cancellationToken)
        {
            IPaginate<StudentModule> studentModules = await _studentModuleRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListStudentModuleListItemDto> response = _mapper.Map<GetListResponse<GetListStudentModuleListItemDto>>(studentModules);
            return response;
        }
    }
}