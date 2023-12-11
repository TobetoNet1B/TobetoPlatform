using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Application: Entity<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }

}
