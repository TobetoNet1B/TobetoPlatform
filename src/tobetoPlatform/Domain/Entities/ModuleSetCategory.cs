using Core.Persistence.Repositories;


namespace Domain.Entities;
public class ModuleSetCategory : Entity<Guid>
{
    public Guid ModuleSetId { get; set; }
    public Guid CategoryOfModuleSetId { get; set; }
    public virtual ModuleSet ModuleSet { get; set; } = null!;
    public virtual CategoryOfModuleSet CategoryOfModuleSet { get; set; } = null!;
    public ModuleSetCategory()
    {
    }

    public ModuleSetCategory(Guid moduleSetId, Guid categoryOfModuleSetId)
    {
        ModuleSetId = moduleSetId;
        CategoryOfModuleSetId = categoryOfModuleSetId;
    }
}
