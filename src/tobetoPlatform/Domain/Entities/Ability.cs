using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Ability: Entity<Guid>
{
    public string Name { get; set; }
    public Guid StudentId { get; set; }
    public Student Student { get; set; }
}
