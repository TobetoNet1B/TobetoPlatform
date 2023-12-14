using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.LessonTags;

public interface ILessonTagsService
{
    Task<LessonTag?> GetAsync(
        Expression<Func<LessonTag, bool>> predicate,
        Func<IQueryable<LessonTag>, IIncludableQueryable<LessonTag, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<LessonTag>?> GetListAsync(
        Expression<Func<LessonTag, bool>>? predicate = null,
        Func<IQueryable<LessonTag>, IOrderedQueryable<LessonTag>>? orderBy = null,
        Func<IQueryable<LessonTag>, IIncludableQueryable<LessonTag, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<LessonTag> AddAsync(LessonTag lessonTag);
    Task<LessonTag> UpdateAsync(LessonTag lessonTag);
    Task<LessonTag> DeleteAsync(LessonTag lessonTag, bool permanent = false);
}
