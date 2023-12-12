using Core.Persistence.Repositories;

namespace Domain.Entities;
public class ParticipantExam: Entity<Guid>
{
    public Guid ParticipantId { get; set; }
    public Participant Participant { get; set; }
    public Guid ExamId { get; set; }
    public Exam Exam { get; set; }
}
