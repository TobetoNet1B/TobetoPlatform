using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;
public class Student : Entity<Guid>
{
    public string? IdentityNumber { get; set; }
    public DateTime? BirthDate { get; set;}
    public string? PhoneNumber { get; set;}
    public string? About { get; set; }
    public string? ImgUrl { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; } = null!;
    public virtual Address Address {  get; set; } = null!;
    public virtual ICollection<Ability> Abilities { get; set; } = null!;
    public virtual ICollection<StudentAppeal> StudentAppeals { get; set; } = null!;
    public virtual ICollection<Survey> Surveys { get; set; } = null!;
    public virtual ICollection<Certificate> Certificates { get; set; } = null!;
    public virtual ICollection<StudentSocialMedia> StudentSocialMedias { get; set; } = null!;
    public virtual ICollection<StudentForeignLanguage> StudentForeignLanguages { get; set; } = null!;
    public virtual ICollection<Education> Educations { get; set; } = null!;
    public virtual ICollection<StudentExam> StudentExams { get; set; } = null!;
    public virtual ICollection<Experience> Experiences { get; set; } = null!;
    public virtual ICollection<StudentModule> StudentModules { get; set; } = null!;
    public virtual ICollection<StudentLesson> StudentLessons { get; set; } = null!;
    public virtual ICollection<StudentClassroom> StudentClassrooms { get; set; } = null!;

    public Student()
    {
        
    }
    public Student(Guid id, string? identityNumber, DateTime? birthDate, string? phoneNumber, string? about, string? imgUrl) : base(id)
    {
        IdentityNumber = identityNumber;
        BirthDate = birthDate;
        PhoneNumber = phoneNumber;
        About = about;
        ImgUrl = imgUrl;
    }
}
