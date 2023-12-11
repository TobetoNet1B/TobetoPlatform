using Core.Security.Entities;

namespace Domain.Entities;
public class Participant : User
{
    public string IdentityNumber { get; set; }
    public DateTime BirthDate { get; set;}
    public string PhoneNumber { get; set;}
    public string? About { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public string? Address { get; set; }
    public string? ImgUrl { get; set; }
    public List<Certificate> Certificates { get; set; }
    public List<SocialMedia> SocialMedias { get; set; }
    public Language LanguageLevel { get; set; }
    public List<Language> Languages { get; set; }
    public List<Education> Educations { get; set; }
    public List<Experience> Experiences { get; set; }
}
