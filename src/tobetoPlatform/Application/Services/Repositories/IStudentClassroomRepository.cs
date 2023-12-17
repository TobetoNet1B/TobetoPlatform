using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IStudentClassroomRepository : IAsyncRepository<StudentClassroom, Guid>, IRepository<StudentClassroom, Guid>
{
}