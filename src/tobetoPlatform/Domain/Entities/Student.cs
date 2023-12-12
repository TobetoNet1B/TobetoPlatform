using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;
public class Student : Entity<Guid>
{
    public User User { get; set; }
    public int UserId { get; set; }
    public string? IdentityNumber { get; set; }
    public DateTime BirthDate { get; set;}
    public string PhoneNumber { get; set;}
    public string? About { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
    public string? District { get; set; }
    public string? Address { get; set; }
    public string? ImgUrl { get; set; }
    public List<Ability> Abilities { get; set; }
    public List<Appeal> Appeals { get; set; }
    public List<Survey> Surveys { get; set; }
    public List<CourseStudent> CourseStudents { get; set; }
    public List<Certificate>? Certificates { get; set; }
    public List<SocialMedia>? SocialMedias { get; set; }
    //public List<ForeignLanguageLevel>? ForeignLanguageLevels { get; set; }
    public List<ForeignLanguage>? ForeignLanguages { get; set; }
    public List<Education>? Educations { get; set; }
    public List<StudentExam>? StudentExams { get; set; }
    public List<Experience>? Experiences { get; set; }
}
