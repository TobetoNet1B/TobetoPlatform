using Application.Features.CourseCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CourseCategories.Queries.GetById;

public class GetByIdCourseCategoryQuery : IRequest<GetByIdCourseCategoryResponse>
{
    public Guid Id { get; set; }

    public class GetByIdCourseCategoryQueryHandler : IRequestHandler<GetByIdCourseCategoryQuery, GetByIdCourseCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseCategoryRepository _courseCategoryRepository;
        private readonly CourseCategoryBusinessRules _courseCategoryBusinessRules;

        public GetByIdCourseCategoryQueryHandler(IMapper mapper, ICourseCategoryRepository courseCategoryRepository, CourseCategoryBusinessRules courseCategoryBusinessRules)
        {
            _mapper = mapper;
            _courseCategoryRepository = courseCategoryRepository;
            _courseCategoryBusinessRules = courseCategoryBusinessRules;
        }

        public async Task<GetByIdCourseCategoryResponse> Handle(GetByIdCourseCategoryQuery request, CancellationToken cancellationToken)
        {
            CourseCategory? courseCategory = await _courseCategoryRepository.GetAsync(predicate: cc => cc.Id == request.Id, cancellationToken: cancellationToken);
            await _courseCategoryBusinessRules.CourseCategoryShouldExistWhenSelected(courseCategory);

            GetByIdCourseCategoryResponse response = _mapper.Map<GetByIdCourseCategoryResponse>(courseCategory);
            return response;
        }
    }
}