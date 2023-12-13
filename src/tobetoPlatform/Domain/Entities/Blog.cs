using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Blog: Entity<Guid>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImgUrl { get; set; }
    public Blog()
    {
        
    }
    public Blog(Guid id,string title, string description, string imgUrl) : base(id)
    {
        Title = title;
        Description = description;
        ImgUrl = imgUrl;
    }
}
