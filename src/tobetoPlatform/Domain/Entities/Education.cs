using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Education: Entity<Guid>
{
    public string University {  get; set; }
    public string Department { get; set; }
    public string Graduation { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool? IsContinueUniversity { get; set; }
    public Guid StudentId { get; set; }
    public virtual Student Student { get; set; } = null!;

    public Education()
    {
        
    }
    public Education(Guid id,string university, string department, string graduation, DateTime startDate, DateTime endDate, bool isContinueUniversity, Guid studentId) : base(id)
    {
        University = university;
        Department = department;
        Graduation = graduation;
        StartDate = startDate;
        EndDate = endDate;
        IsContinueUniversity = isContinueUniversity;
        StudentId = studentId;
    }
}
