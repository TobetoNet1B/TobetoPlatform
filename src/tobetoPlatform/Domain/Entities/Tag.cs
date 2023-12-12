using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Tag: Entity<Guid>
{
    public string TagName { get; set; }
}
