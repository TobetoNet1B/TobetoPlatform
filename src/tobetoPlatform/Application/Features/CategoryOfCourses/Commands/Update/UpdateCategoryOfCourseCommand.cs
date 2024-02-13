using Application.Features.CategoryOfCourses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CategoryOfCourses.Commands.Update;

public class UpdateCategoryOfCourseCommand : IRequest<UpdatedCategoryOfCourseResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool? IsActive { get; set; }

    public class UpdateCategoryOfCourseCommandHandler : IRequestHandler<UpdateCategoryOfCourseCommand, UpdatedCategoryOfCourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryOfCourseRepository _categoryOfCourseRepository;
        private readonly CategoryOfCourseBusinessRules _categoryOfCourseBusinessRules;

        public UpdateCategoryOfCourseCommandHandler(IMapper mapper, ICategoryOfCourseRepository categoryOfCourseRepository,
                                         CategoryOfCourseBusinessRules categoryOfCourseBusinessRules)
        {
            _mapper = mapper;
            _categoryOfCourseRepository = categoryOfCourseRepository;
            _categoryOfCourseBusinessRules = categoryOfCourseBusinessRules;
        }

        public async Task<UpdatedCategoryOfCourseResponse> Handle(UpdateCategoryOfCourseCommand request, CancellationToken cancellationToken)
        {
            CategoryOfCourse? categoryOfCourse = await _categoryOfCourseRepository.GetAsync(predicate: coc => coc.Id == request.Id, cancellationToken: cancellationToken);
            await _categoryOfCourseBusinessRules.CategoryOfCourseShouldExistWhenSelected(categoryOfCourse);
            categoryOfCourse = _mapper.Map(request, categoryOfCourse);

            await _categoryOfCourseRepository.UpdateAsync(categoryOfCourse!);

            UpdatedCategoryOfCourseResponse response = _mapper.Map<UpdatedCategoryOfCourseResponse>(categoryOfCourse);
            return response;
        }
    }
}