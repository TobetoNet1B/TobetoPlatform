using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SoftwareLanguageRepository : EfRepositoryBase<SoftwareLanguage, Guid, BaseDbContext>, ISoftwareLanguageRepository
{
    public SoftwareLanguageRepository(BaseDbContext context) : base(context)
    {
    }
}