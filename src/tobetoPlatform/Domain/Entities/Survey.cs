using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Survey: Entity<Guid>
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public Guid ParticipantId { get; set; }
    public Participant Participant { get; set; }
}
