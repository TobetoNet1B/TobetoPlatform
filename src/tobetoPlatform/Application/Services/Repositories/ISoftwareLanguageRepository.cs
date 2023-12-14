using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISoftwareLanguageRepository : IAsyncRepository<SoftwareLanguage, Guid>, IRepository<SoftwareLanguage, Guid>
{
}