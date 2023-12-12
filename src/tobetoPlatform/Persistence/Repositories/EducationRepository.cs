using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class EducationRepository : EfRepositoryBase<Education, Guid, BaseDbContext>, IEducationRepository
{
    public EducationRepository(BaseDbContext context) : base(context)
    {
    }
}