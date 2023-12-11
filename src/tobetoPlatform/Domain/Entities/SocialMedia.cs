using Core.Persistence.Repositories;

namespace Domain.Entities;
public class SocialMedia: Entity<Guid>
{
    public string Name { get; set; }
    public string Icon { get; set; }
    public string SocialMediaUrl { get; set; }
    public Guid ParticipantId { get; set; }
    public Participant Participant { get; set; }
}
