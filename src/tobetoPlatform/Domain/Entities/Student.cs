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
    public Guid? CountryId { get; set; }
    public Guid? CityId { get; set; }
    public Guid? DistrictId { get; set; }
    public string? Address { get; set; }
    public string? ImgUrl { get; set; }
    public virtual City City { get; set; } = null!;
    public virtual Country Country { get; set; } = null!;
    public virtual District District { get; set; } = null!;
    public virtual ICollection<Ability> Abilities { get; set; } = null!;
    public virtual ICollection<StudentAppeal> StudentAppeals { get; set; } = null!;
    public virtual ICollection<Survey> Surveys { get; set; } = null!;
    public virtual ICollection<Certificate> Certificates { get; set; } = null!;
    public virtual ICollection<SocialMedia> SocialMedias { get; set; } = null!;
    public virtual ICollection<StudentForeignLanguage> StudentForeignLanguages { get; set; } = null!;
    public virtual ICollection<Education> Educations { get; set; } = null!;
    public virtual ICollection<StudentExam> StudentExams { get; set; } = null!;
    public virtual ICollection<Experience> Experiences { get; set; } = null!;
    public virtual ICollection<StudentModule> StudentModules { get; set; } = null!;
    public Student()
    {
        
    }

    public Student(Guid id,int userId, User user, string? identityNumber, DateTime? birthDate, string? phoneNumber, string? about, Guid? countryId, Guid? cityId, Guid? districtId, string? address, string? imgUrl, City city, Country country, District district, ICollection<Ability> abilities, ICollection<StudentAppeal> studentAppeals, ICollection<Survey> surveys, ICollection<Certificate> certificates, ICollection<SocialMedia> socialMedias, ICollection<StudentForeignLanguage> studentForeignLanguages, ICollection<Education> educations, ICollection<StudentExam> studentExams, ICollection<Experience> experiences, ICollection<StudentModule> studentModules):base(id)
    {
        UserId = userId;
        User = user;
        IdentityNumber = identityNumber;
        BirthDate = birthDate;
        PhoneNumber = phoneNumber;
        About = about;
        CountryId = countryId;
        CityId = cityId;
        DistrictId = districtId;
        Address = address;
        ImgUrl = imgUrl;
        City = city;
        Country = country;
        District = district;
        Abilities = abilities;
        StudentAppeals = studentAppeals;
        Surveys = surveys;
        Certificates = certificates;
        SocialMedias = socialMedias;
        StudentForeignLanguages = studentForeignLanguages;
        Educations = educations;
        StudentExams = studentExams;
        Experiences = experiences;
        StudentModules = studentModules;
    }
}
