using Core.Persistence.Repositories;

namespace Domain.Entities;
public class CourseParticipant: Entity<Guid>
{
    public Guid CourseId { get; set; }
    public Course Course { get; set; }
    public Guid ParticipantId { get; set; }
    public Participant Participant { get; set; }
}
