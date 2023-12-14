using Application.Features.CourseCategories.Constants;
using Application.Features.CourseCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CourseCategories.Commands.Delete;

public class DeleteCourseCategoryCommand : IRequest<DeletedCourseCategoryResponse>
{
    public Guid Id { get; set; }

    public class DeleteCourseCategoryCommandHandler : IRequestHandler<DeleteCourseCategoryCommand, DeletedCourseCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseCategoryRepository _courseCategoryRepository;
        private readonly CourseCategoryBusinessRules _courseCategoryBusinessRules;

        public DeleteCourseCategoryCommandHandler(IMapper mapper, ICourseCategoryRepository courseCategoryRepository,
                                         CourseCategoryBusinessRules courseCategoryBusinessRules)
        {
            _mapper = mapper;
            _courseCategoryRepository = courseCategoryRepository;
            _courseCategoryBusinessRules = courseCategoryBusinessRules;
        }

        public async Task<DeletedCourseCategoryResponse> Handle(DeleteCourseCategoryCommand request, CancellationToken cancellationToken)
        {
            CourseCategory? courseCategory = await _courseCategoryRepository.GetAsync(predicate: cc => cc.Id == request.Id, cancellationToken: cancellationToken);
            await _courseCategoryBusinessRules.CourseCategoryShouldExistWhenSelected(courseCategory);

            await _courseCategoryRepository.DeleteAsync(courseCategory!);

            DeletedCourseCategoryResponse response = _mapper.Map<DeletedCourseCategoryResponse>(courseCategory);
            return response;
        }
    }
}