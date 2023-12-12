using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Announcement: Entity<Guid>
{
    public string Title { get; set; }
    public string Description { get; set; }
}
