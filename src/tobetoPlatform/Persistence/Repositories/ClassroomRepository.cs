using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ClassroomRepository : EfRepositoryBase<Classroom, Guid, BaseDbContext>, IClassroomRepository
{
    public ClassroomRepository(BaseDbContext context) : base(context)
    {
    }
}