using Application.Features.CategoryOfCourses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CategoryOfCourses.Queries.GetById;

public class GetByIdCategoryOfCourseQuery : IRequest<GetByIdCategoryOfCourseResponse>
{
    public Guid Id { get; set; }

    public class GetByIdCategoryOfCourseQueryHandler : IRequestHandler<GetByIdCategoryOfCourseQuery, GetByIdCategoryOfCourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryOfCourseRepository _categoryOfCourseRepository;
        private readonly CategoryOfCourseBusinessRules _categoryOfCourseBusinessRules;

        public GetByIdCategoryOfCourseQueryHandler(IMapper mapper, ICategoryOfCourseRepository categoryOfCourseRepository, CategoryOfCourseBusinessRules categoryOfCourseBusinessRules)
        {
            _mapper = mapper;
            _categoryOfCourseRepository = categoryOfCourseRepository;
            _categoryOfCourseBusinessRules = categoryOfCourseBusinessRules;
        }

        public async Task<GetByIdCategoryOfCourseResponse> Handle(GetByIdCategoryOfCourseQuery request, CancellationToken cancellationToken)
        {
            CategoryOfCourse? categoryOfCourse = await _categoryOfCourseRepository.GetAsync(predicate: coc => coc.Id == request.Id, cancellationToken: cancellationToken);
            await _categoryOfCourseBusinessRules.CategoryOfCourseShouldExistWhenSelected(categoryOfCourse);

            GetByIdCategoryOfCourseResponse response = _mapper.Map<GetByIdCategoryOfCourseResponse>(categoryOfCourse);
            return response;
        }
    }
}