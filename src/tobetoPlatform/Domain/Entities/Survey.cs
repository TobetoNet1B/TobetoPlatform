using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Survey: Entity<Guid>
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public Guid StudentId { get; set; }
    public Student Student { get; set; }
}
