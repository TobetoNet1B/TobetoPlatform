using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ILessonTagRepository : IAsyncRepository<LessonTag, Guid>, IRepository<LessonTag, Guid>
{
}