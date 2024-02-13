using Core.Persistence.Repositories;


namespace Domain.Entities;
public class ModuleType : Entity<Guid>
{
    public string Name { get; set; }
    public virtual ICollection<ModuleSet> ModuleSets { get; set; } = null!;
    public ModuleType()
    {
    }

    public ModuleType(Guid id, string name) : base(id)
    {
        Name = name;
    }
}
