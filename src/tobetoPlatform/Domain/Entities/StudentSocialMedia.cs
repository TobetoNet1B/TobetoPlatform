using Core.Persistence.Repositories;


namespace Domain.Entities;
public class StudentSocialMedia : Entity<Guid>
{
    public Guid StudentId { get; set; }
    public Guid SocialMediaId { get; set; }
    public string? SocialMediaUrl { get; set; }
    public virtual Student Student { get; set; } = null!;
    public virtual SocialMedia SocialMedia { get; set; } = null!;

    public StudentSocialMedia()
    {
    }

    public StudentSocialMedia(Guid id, Guid studentId, Guid socialMediaId, string? socialMediaUrl) : base(id)
    {
        StudentId = studentId;
        SocialMediaId = socialMediaId;
        SocialMediaUrl = socialMediaUrl;
    }
}
