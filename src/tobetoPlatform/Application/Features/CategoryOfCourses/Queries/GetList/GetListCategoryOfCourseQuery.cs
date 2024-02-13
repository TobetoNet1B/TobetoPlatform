using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.CategoryOfCourses.Queries.GetList;

public class GetListCategoryOfCourseQuery : IRequest<GetListResponse<GetListCategoryOfCourseListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListCategoryOfCourseQueryHandler : IRequestHandler<GetListCategoryOfCourseQuery, GetListResponse<GetListCategoryOfCourseListItemDto>>
    {
        private readonly ICategoryOfCourseRepository _categoryOfCourseRepository;
        private readonly IMapper _mapper;

        public GetListCategoryOfCourseQueryHandler(ICategoryOfCourseRepository categoryOfCourseRepository, IMapper mapper)
        {
            _categoryOfCourseRepository = categoryOfCourseRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCategoryOfCourseListItemDto>> Handle(GetListCategoryOfCourseQuery request, CancellationToken cancellationToken)
        {
            IPaginate<CategoryOfCourse> categoryOfCourses = await _categoryOfCourseRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListCategoryOfCourseListItemDto> response = _mapper.Map<GetListResponse<GetListCategoryOfCourseListItemDto>>(categoryOfCourses);
            return response;
        }
    }
}