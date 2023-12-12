using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IForeignLanguageLevelRepository : IAsyncRepository<ForeignLanguageLevel, Guid>, IRepository<ForeignLanguageLevel, Guid>
{
}