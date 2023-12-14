using Application.Features.LessonTags.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.LessonTags;

public class LessonTagsManager : ILessonTagsService
{
    private readonly ILessonTagRepository _lessonTagRepository;
    private readonly LessonTagBusinessRules _lessonTagBusinessRules;

    public LessonTagsManager(ILessonTagRepository lessonTagRepository, LessonTagBusinessRules lessonTagBusinessRules)
    {
        _lessonTagRepository = lessonTagRepository;
        _lessonTagBusinessRules = lessonTagBusinessRules;
    }

    public async Task<LessonTag?> GetAsync(
        Expression<Func<LessonTag, bool>> predicate,
        Func<IQueryable<LessonTag>, IIncludableQueryable<LessonTag, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        LessonTag? lessonTag = await _lessonTagRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return lessonTag;
    }

    public async Task<IPaginate<LessonTag>?> GetListAsync(
        Expression<Func<LessonTag, bool>>? predicate = null,
        Func<IQueryable<LessonTag>, IOrderedQueryable<LessonTag>>? orderBy = null,
        Func<IQueryable<LessonTag>, IIncludableQueryable<LessonTag, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<LessonTag> lessonTagList = await _lessonTagRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return lessonTagList;
    }

    public async Task<LessonTag> AddAsync(LessonTag lessonTag)
    {
        LessonTag addedLessonTag = await _lessonTagRepository.AddAsync(lessonTag);

        return addedLessonTag;
    }

    public async Task<LessonTag> UpdateAsync(LessonTag lessonTag)
    {
        LessonTag updatedLessonTag = await _lessonTagRepository.UpdateAsync(lessonTag);

        return updatedLessonTag;
    }

    public async Task<LessonTag> DeleteAsync(LessonTag lessonTag, bool permanent = false)
    {
        LessonTag deletedLessonTag = await _lessonTagRepository.DeleteAsync(lessonTag);

        return deletedLessonTag;
    }
}
