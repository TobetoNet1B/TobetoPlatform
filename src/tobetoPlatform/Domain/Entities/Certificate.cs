using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Certificate: Entity<Guid>
{
    public string Name { get; set; }
    public string FileType { get; set; }
    public Guid ParticipantId { get; set; }
    public Participant Participant { get; set; }
}
