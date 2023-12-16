using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.StudentForeignLanguages.Queries.GetList;

public class GetListStudentForeignLanguageQuery : IRequest<GetListResponse<GetListStudentForeignLanguageListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListStudentForeignLanguageQueryHandler : IRequestHandler<GetListStudentForeignLanguageQuery, GetListResponse<GetListStudentForeignLanguageListItemDto>>
    {
        private readonly IStudentForeignLanguageRepository _studentForeignLanguageRepository;
        private readonly IMapper _mapper;

        public GetListStudentForeignLanguageQueryHandler(IStudentForeignLanguageRepository studentForeignLanguageRepository, IMapper mapper)
        {
            _studentForeignLanguageRepository = studentForeignLanguageRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListStudentForeignLanguageListItemDto>> Handle(GetListStudentForeignLanguageQuery request, CancellationToken cancellationToken)
        {
            IPaginate<StudentForeignLanguage> studentForeignLanguages = await _studentForeignLanguageRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListStudentForeignLanguageListItemDto> response = _mapper.Map<GetListResponse<GetListStudentForeignLanguageListItemDto>>(studentForeignLanguages);
            return response;
        }
    }
}