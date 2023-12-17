using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class StudentClassroomRepository : EfRepositoryBase<StudentClassroom, Guid, BaseDbContext>, IStudentClassroomRepository
{
    public StudentClassroomRepository(BaseDbContext context) : base(context)
    {
    }
}