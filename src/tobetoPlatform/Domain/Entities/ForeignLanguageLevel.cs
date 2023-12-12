using Core.Persistence.Repositories;

namespace Domain.Entities;
public class ForeignLanguageLevel:Entity<Guid>
{
    public string Name { get; set; }
    public virtual ForeignLanguage? ForeignLanguage { get; set; } = null!;
}
