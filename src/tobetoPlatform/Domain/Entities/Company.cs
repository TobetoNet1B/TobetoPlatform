using Core.Persistence.Repositories;


namespace Domain.Entities;
public class Company:Entity<Guid>
{
    public string Name { get; set; }
    public virtual ICollection<ModuleSet> ModuleSets { get; set; } = null!;

    public Company()
    {
        
    }
    public Company(Guid id,string name) : base(id)
    {
        Name = name;
    }
}
