using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.StudentExams.Queries.GetList;

public class GetListStudentExamQuery : IRequest<GetListResponse<GetListStudentExamListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListStudentExamQueryHandler : IRequestHandler<GetListStudentExamQuery, GetListResponse<GetListStudentExamListItemDto>>
    {
        private readonly IStudentExamRepository _studentExamRepository;
        private readonly IMapper _mapper;

        public GetListStudentExamQueryHandler(IStudentExamRepository studentExamRepository, IMapper mapper)
        {
            _studentExamRepository = studentExamRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListStudentExamListItemDto>> Handle(GetListStudentExamQuery request, CancellationToken cancellationToken)
        {
            IPaginate<StudentExam> studentExams = await _studentExamRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListStudentExamListItemDto> response = _mapper.Map<GetListResponse<GetListStudentExamListItemDto>>(studentExams);
            return response;
        }
    }
}