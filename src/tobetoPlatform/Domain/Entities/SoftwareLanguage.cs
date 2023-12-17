using Core.Persistence.Repositories;

namespace Domain.Entities;
public class SoftwareLanguage:Entity<Guid>
{
    public string Name { get; set; }
    public virtual ICollection<ModuleSet> ModuleSets { get; set; } = null!;

    public SoftwareLanguage()
    {
        
    }
    public SoftwareLanguage(Guid id,string name) : base(id)
    {
        Name = name;
    }
}
