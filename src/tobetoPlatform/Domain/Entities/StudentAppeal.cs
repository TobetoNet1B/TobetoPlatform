using Core.Persistence.Repositories;


namespace Domain.Entities;
public class StudentAppeal:Entity<Guid>
{
    public Guid AppealId { get; set; }
    public Guid StudentId { get; set; }
    public bool? IsApproved { get; set; }
    public virtual Appeal Appeal { get; set; } = null!;
    public virtual Student Student { get; set; } = null!;

    public StudentAppeal()
    {
        
    }
    public StudentAppeal(Guid id,Guid appealId, Guid studentId, bool? isApproved) : base(id)
    {
        AppealId = appealId;
        StudentId = studentId;
        IsApproved = isApproved;
    }
}
