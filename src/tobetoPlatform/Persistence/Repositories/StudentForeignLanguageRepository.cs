using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class StudentForeignLanguageRepository : EfRepositoryBase<StudentForeignLanguage, Guid, BaseDbContext>, IStudentForeignLanguageRepository
{
    public StudentForeignLanguageRepository(BaseDbContext context) : base(context)
    {
    }
}