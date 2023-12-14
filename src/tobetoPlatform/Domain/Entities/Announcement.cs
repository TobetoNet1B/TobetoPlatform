using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Announcement: Entity<Guid>
{
    public string Title { get; set; }
    public string Description { get; set; }

    public Announcement()
    {
        
    }
    public Announcement(Guid id,string title, string description) : base(id)
    {
        Title = title;
        Description = description;
    }
}
