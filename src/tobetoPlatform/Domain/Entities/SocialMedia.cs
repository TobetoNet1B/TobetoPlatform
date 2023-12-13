using Core.Persistence.Repositories;

namespace Domain.Entities;
public class SocialMedia: Entity<Guid>
{
    public string Name { get; set; }
    public string Icon { get; set; }
    public string SocialMediaUrl { get; set; }
    public Guid StudentId { get; set; }
    public virtual Student Student { get; set; } = null!;
    public SocialMedia()
    {
        
    }

    public SocialMedia(Guid id,string name, string icon, string socialMediaUrl, Guid studentId, Student student) : base(id)
    {
        Name = name;
        Icon = icon;
        SocialMediaUrl = socialMediaUrl;
        StudentId = studentId;
        Student = student;
    }
}
