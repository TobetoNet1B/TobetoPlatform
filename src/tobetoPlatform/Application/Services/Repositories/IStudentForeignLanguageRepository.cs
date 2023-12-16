using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IStudentForeignLanguageRepository : IAsyncRepository<StudentForeignLanguage, Guid>, IRepository<StudentForeignLanguage, Guid>
{
}