using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Appeal: Entity<Guid>
{
    // Başvurular
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid StudentId { get; set; }
    public Student Student { get; set; }

}
