using Core.Persistence.Repositories;

namespace Domain.Entities;
public class CategoryOfModuleSet: Entity<Guid>
{
    public string Name { get; set; }
    public bool? IsActive { get; set; }
    public virtual ICollection<ModuleSetCategory> ModuleSetCategories { get; set; } = null!;

    public CategoryOfModuleSet()
    {
        
    }
    public CategoryOfModuleSet(Guid id,string name, bool? isActive) : base(id)
    {
        Name = name;
        IsActive = isActive;
    }
}
