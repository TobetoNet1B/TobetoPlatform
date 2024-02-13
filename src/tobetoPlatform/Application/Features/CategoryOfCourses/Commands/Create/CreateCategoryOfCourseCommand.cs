using Application.Features.CategoryOfCourses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CategoryOfCourses.Commands.Create;

public class CreateCategoryOfCourseCommand : IRequest<CreatedCategoryOfCourseResponse>
{
    public string Name { get; set; }
    public bool? IsActive { get; set; }

    public class CreateCategoryOfCourseCommandHandler : IRequestHandler<CreateCategoryOfCourseCommand, CreatedCategoryOfCourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryOfCourseRepository _categoryOfCourseRepository;
        private readonly CategoryOfCourseBusinessRules _categoryOfCourseBusinessRules;

        public CreateCategoryOfCourseCommandHandler(IMapper mapper, ICategoryOfCourseRepository categoryOfCourseRepository,
                                         CategoryOfCourseBusinessRules categoryOfCourseBusinessRules)
        {
            _mapper = mapper;
            _categoryOfCourseRepository = categoryOfCourseRepository;
            _categoryOfCourseBusinessRules = categoryOfCourseBusinessRules;
        }

        public async Task<CreatedCategoryOfCourseResponse> Handle(CreateCategoryOfCourseCommand request, CancellationToken cancellationToken)
        {
            CategoryOfCourse categoryOfCourse = _mapper.Map<CategoryOfCourse>(request);

            await _categoryOfCourseRepository.AddAsync(categoryOfCourse);

            CreatedCategoryOfCourseResponse response = _mapper.Map<CreatedCategoryOfCourseResponse>(categoryOfCourse);
            return response;
        }
    }
}