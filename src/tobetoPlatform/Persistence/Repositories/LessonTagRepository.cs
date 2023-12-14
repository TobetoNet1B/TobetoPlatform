using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class LessonTagRepository : EfRepositoryBase<LessonTag, Guid, BaseDbContext>, ILessonTagRepository
{
    public LessonTagRepository(BaseDbContext context) : base(context)
    {
    }
}