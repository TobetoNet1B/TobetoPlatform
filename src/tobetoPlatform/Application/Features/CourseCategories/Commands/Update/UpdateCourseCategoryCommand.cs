using Application.Features.CourseCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CourseCategories.Commands.Update;

public class UpdateCourseCategoryCommand : IRequest<UpdatedCourseCategoryResponse>
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public Guid CategoryId { get; set; }

    public class UpdateCourseCategoryCommandHandler : IRequestHandler<UpdateCourseCategoryCommand, UpdatedCourseCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseCategoryRepository _courseCategoryRepository;
        private readonly CourseCategoryBusinessRules _courseCategoryBusinessRules;

        public UpdateCourseCategoryCommandHandler(IMapper mapper, ICourseCategoryRepository courseCategoryRepository,
                                         CourseCategoryBusinessRules courseCategoryBusinessRules)
        {
            _mapper = mapper;
            _courseCategoryRepository = courseCategoryRepository;
            _courseCategoryBusinessRules = courseCategoryBusinessRules;
        }

        public async Task<UpdatedCourseCategoryResponse> Handle(UpdateCourseCategoryCommand request, CancellationToken cancellationToken)
        {
            CourseCategory? courseCategory = await _courseCategoryRepository.GetAsync(predicate: cc => cc.Id == request.Id, cancellationToken: cancellationToken);
            await _courseCategoryBusinessRules.CourseCategoryShouldExistWhenSelected(courseCategory);
            courseCategory = _mapper.Map(request, courseCategory);

            await _courseCategoryRepository.UpdateAsync(courseCategory!);

            UpdatedCourseCategoryResponse response = _mapper.Map<UpdatedCourseCategoryResponse>(courseCategory);
            return response;
        }
    }
}