using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Experience : Entity<Guid>
{
    public string CompanyName { get; set; }
    public string Position { get; set;}
    public string Sector { get; set;}
    public string City { get; set;}
    public DateTime StartDate { get; set;}
    public DateTime EndDate { get; set;}
    public bool IsContinueJob { get; set;}
    public Guid ParticipantId { get; set; }
    public Participant Participant { get; set; }
}
