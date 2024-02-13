using Application.Features.CategoryOfCourses.Constants;
using Application.Features.CategoryOfCourses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CategoryOfCourses.Commands.Delete;

public class DeleteCategoryOfCourseCommand : IRequest<DeletedCategoryOfCourseResponse>
{
    public Guid Id { get; set; }

    public class DeleteCategoryOfCourseCommandHandler : IRequestHandler<DeleteCategoryOfCourseCommand, DeletedCategoryOfCourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryOfCourseRepository _categoryOfCourseRepository;
        private readonly CategoryOfCourseBusinessRules _categoryOfCourseBusinessRules;

        public DeleteCategoryOfCourseCommandHandler(IMapper mapper, ICategoryOfCourseRepository categoryOfCourseRepository,
                                         CategoryOfCourseBusinessRules categoryOfCourseBusinessRules)
        {
            _mapper = mapper;
            _categoryOfCourseRepository = categoryOfCourseRepository;
            _categoryOfCourseBusinessRules = categoryOfCourseBusinessRules;
        }

        public async Task<DeletedCategoryOfCourseResponse> Handle(DeleteCategoryOfCourseCommand request, CancellationToken cancellationToken)
        {
            CategoryOfCourse? categoryOfCourse = await _categoryOfCourseRepository.GetAsync(predicate: coc => coc.Id == request.Id, cancellationToken: cancellationToken);
            await _categoryOfCourseBusinessRules.CategoryOfCourseShouldExistWhenSelected(categoryOfCourse);

            await _categoryOfCourseRepository.DeleteAsync(categoryOfCourse!);

            DeletedCategoryOfCourseResponse response = _mapper.Map<DeletedCategoryOfCourseResponse>(categoryOfCourse);
            return response;
        }
    }
}