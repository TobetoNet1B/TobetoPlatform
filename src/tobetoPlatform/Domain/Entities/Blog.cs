using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Blog: Entity<Guid>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImgUrl { get; set; }
}
