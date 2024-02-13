using Core.Persistence.Repositories;

namespace Domain.Entities;
public class ClassroomModule : Entity<Guid>
{
    public Guid ClassroomId { get; set; }
    public Guid ModuleSetId { get; set; }
    public DateTime? ClassroomStartDate { get; set; }
    public DateTime? ClassroomEndDate { get; set; }
    public virtual Classroom Classroom { get; set; } = null!;
    public virtual ModuleSet ModuleSet { get; set; } = null!;

    public ClassroomModule()
    {

    }
    public ClassroomModule(Guid id, Guid classroomId, Guid moduleSetId, DateTime? classroomStartDate, DateTime? classroomEndDate) : base(id)
    {
        ClassroomId = classroomId;
        ModuleSetId = moduleSetId;
        ClassroomStartDate = classroomStartDate;
        ClassroomEndDate = classroomEndDate;
    }
}
