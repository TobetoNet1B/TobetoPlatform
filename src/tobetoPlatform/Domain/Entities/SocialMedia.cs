using Core.Persistence.Repositories;

namespace Domain.Entities;
public class SocialMedia: Entity<Guid>
{
    public string Name { get; set; }
    public string? IconUrl { get; set; }
    public virtual ICollection<StudentSocialMedia> StudentSocialMedias { get; set; } = null!;

    public SocialMedia()
    {
        
    }
    public SocialMedia(Guid id,string name, string? iconUrl) : base(id)
    {
        Name = name;
        IconUrl = iconUrl;
    }
}
