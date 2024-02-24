using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Experience : Entity<Guid>
{
    public string CompanyName { get; set; }
    public string Position { get; set;}
    public string Sector { get; set;}
    public Guid CityId { get; set;}
    public DateTime StartDate { get; set;}
    public DateTime? EndDate { get; set;}
    public bool? IsContinueJob { get; set;}
    public Guid StudentId { get; set; }
    public virtual Student Student { get; set; } = null!;
    public virtual City City { get; set; } = null!;

    public Experience()
    {
        
    }
    public Experience(Guid id,string companyName, string position, string sector, Guid cityId, DateTime startDate, DateTime endDate, bool isContinueJob, Guid studentId) : base(id)
    {
        CompanyName = companyName;
        Position = position;
        Sector = sector;
        CityId = cityId;
        StartDate = startDate;
        EndDate = endDate;
        IsContinueJob = isContinueJob;
        StudentId = studentId;
    }
}
