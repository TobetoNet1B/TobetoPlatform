using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class StudentModuleRepository : EfRepositoryBase<StudentModule, Guid, BaseDbContext>, IStudentModuleRepository
{
    public StudentModuleRepository(BaseDbContext context) : base(context)
    {
    }
}