using Core.Persistence.Repositories;

namespace Domain.Entities;
public class StudentModule:Entity<Guid>
{
    public Guid StudentId { get; set; }
    public Guid ModuleSetId { get; set; }
    public int? TimeSpent { get; set; }
    public virtual Student Student { get; set; } = null!;
    public virtual ModuleSet ModuleSet { get; set; } = null!;

    public StudentModule()
    {
        
    }

    public StudentModule(Guid id, Guid studentId, Guid moduleSetId, int? timeSpent):base(id)
    {
        StudentId = studentId;
        ModuleSetId = moduleSetId;
        TimeSpent = timeSpent;
    }
}
