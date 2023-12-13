using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;
public class Student : Entity<Guid>
{
    public int UserId { get; set; }
    public virtual User User { get; set; } = null!;
    public string? IdentityNumber { get; set; }
    public DateTime? BirthDate { get; set;}
    public string? PhoneNumber { get; set;}
    public string? About { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
    public string? District { get; set; }
    public string? Address { get; set; }
    public string? ImgUrl { get; set; }
    public virtual ICollection<Ability>? Abilities { get; set; } = null!;
    public virtual ICollection<Appeal>? Appeals { get; set; } = null!;
    public virtual ICollection<Survey>? Surveys { get; set; } = null!;
    public virtual ICollection<CourseStudent>? CourseStudents { get; set; } = null!;
    public virtual ICollection<Certificate>? Certificates { get; set; } = null!;
    public virtual ICollection<SocialMedia>? SocialMedias { get; set; } = null!;
    public virtual ICollection<ForeignLanguage>? ForeignLanguages { get; set; } = null!;
    public virtual ICollection<Education>? Educations { get; set; } = null!;
    public virtual ICollection<StudentExam>? StudentExams { get; set; } = null!;
    public virtual ICollection<Experience>? Experiences { get; set; } = null!;
    public virtual ICollection<StudentModule> StudentModules { get; set; } = null!;
}
