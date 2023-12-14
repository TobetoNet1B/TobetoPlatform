using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.LessonTags.Queries.GetList;

public class GetListLessonTagQuery : IRequest<GetListResponse<GetListLessonTagListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListLessonTagQueryHandler : IRequestHandler<GetListLessonTagQuery, GetListResponse<GetListLessonTagListItemDto>>
    {
        private readonly ILessonTagRepository _lessonTagRepository;
        private readonly IMapper _mapper;

        public GetListLessonTagQueryHandler(ILessonTagRepository lessonTagRepository, IMapper mapper)
        {
            _lessonTagRepository = lessonTagRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListLessonTagListItemDto>> Handle(GetListLessonTagQuery request, CancellationToken cancellationToken)
        {
            IPaginate<LessonTag> lessonTags = await _lessonTagRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListLessonTagListItemDto> response = _mapper.Map<GetListResponse<GetListLessonTagListItemDto>>(lessonTags);
            return response;
        }
    }
}