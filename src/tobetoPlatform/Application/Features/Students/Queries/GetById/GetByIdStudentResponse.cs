using Core.Application.Responses;
using Core.Security.Entities;
using Domain.Entities;

namespace Application.Features.Students.Queries.GetById;

public class GetByIdStudentResponse : IResponse
{
    public Guid Id { get; set; }
    public string? IdentityNumber { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? PhoneNumber { get; set; }
    public string? About { get; set; }
    public string? ImgUrl { get; set; }

    public UserDto User { get; set; }
    public List<StudentExamDto> StudentExams { get; set; } = new List<StudentExamDto>();
    public List<ExperiencesDto>? Experiences { get; set; } = new List<ExperiencesDto>();
    public List<StudentForeignLanguagesDto>? StudentForeignLanguages { get; set; } = new List<StudentForeignLanguagesDto>();
    public List<StudentClassroomsDto>? StudentClassrooms { get; set; } = new List<StudentClassroomsDto>();
    public List<SocialMediasDto>? SocialMedias { get; set; } = new List<SocialMediasDto>();
    public List<EducationsDto>? Educations { get; set; } = new List<EducationsDto>();
    public List<CertificatesDto>? Certificates { get; set; } = new List<CertificatesDto>();
    public List<AbilitiesDto>? Abilities { get; set; } = new List<AbilitiesDto>();
    


}