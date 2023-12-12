using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Education: Entity<Guid>
{
    public string EducationState { get; set; }
    public string University {  get; set; }
    public string Department { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsContinueUniversity { get; set; }
    public Guid ParticipantId { get; set; }
    public Participant Participant { get; set; }
}
