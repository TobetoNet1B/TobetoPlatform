using Application.Features.CourseCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CourseCategories.Commands.Create;

public class CreateCourseCategoryCommand : IRequest<CreatedCourseCategoryResponse>
{
    public Guid CourseId { get; set; }
    public Guid CategoryId { get; set; }

    public class CreateCourseCategoryCommandHandler : IRequestHandler<CreateCourseCategoryCommand, CreatedCourseCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseCategoryRepository _courseCategoryRepository;
        private readonly CourseCategoryBusinessRules _courseCategoryBusinessRules;

        public CreateCourseCategoryCommandHandler(IMapper mapper, ICourseCategoryRepository courseCategoryRepository,
                                         CourseCategoryBusinessRules courseCategoryBusinessRules)
        {
            _mapper = mapper;
            _courseCategoryRepository = courseCategoryRepository;
            _courseCategoryBusinessRules = courseCategoryBusinessRules;
        }

        public async Task<CreatedCourseCategoryResponse> Handle(CreateCourseCategoryCommand request, CancellationToken cancellationToken)
        {
            CourseCategory courseCategory = _mapper.Map<CourseCategory>(request);

            await _courseCategoryRepository.AddAsync(courseCategory);

            CreatedCourseCategoryResponse response = _mapper.Map<CreatedCourseCategoryResponse>(courseCategory);
            return response;
        }
    }
}