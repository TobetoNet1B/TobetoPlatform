using Core.Persistence.Repositories;

namespace Domain.Entities;
public class CourseModule:Entity<Guid>
{
    public Guid CourseId { get; set; }
    public Guid ModuleSetId { get; set; }
    public virtual Course Course { get; set; } = null!;
    public virtual ModuleSet ModuleSet { get; set; } = null!;

    public CourseModule()
    {
        
    }

    public CourseModule(Guid id, Guid courseId, Guid moduleSetId):base(id)
    {
        CourseId = courseId;
        ModuleSetId = moduleSetId;
    }
}
