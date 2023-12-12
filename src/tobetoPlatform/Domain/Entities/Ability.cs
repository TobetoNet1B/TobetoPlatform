using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Ability: Entity<Guid>
{
    public string Name { get; set; }
    public int StudentId { get; set; }
    public virtual Student? Student { get; set; } = null!;
}
