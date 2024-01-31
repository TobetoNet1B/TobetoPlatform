using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Ability: Entity<Guid>
{
    public string Name { get; set; }
    public Guid StudentId { get; set; }
    public virtual Student Student { get; set; } = null!;

    public Ability()
    {
        
    }
    public Ability(Guid id, string name, Guid studentId) : base(id)
    {
        Name = name;
        StudentId = studentId;
    }
}
