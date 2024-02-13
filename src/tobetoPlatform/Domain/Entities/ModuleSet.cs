using Core.Persistence.Repositories;

namespace Domain.Entities;
public class ModuleSet : Entity<Guid>
{
    public string Name { get; set; }
    public string? EducationType { get; set; }// Dijital gelişim, Profesyonel gelişim vb.
    public string? CourseLevel { get; set; }
    public string? Topic { get; set; }
    public Guid? SoftwareLanguageId { get; set; }
    public Guid? InstructorId { get; set; }
    public string? ActivityStatus { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? EstimatedTime { get; set; }
    public string? ImgUrl { get; set; }
    public Guid? CompanyId { get; set; }
    public Guid? ModuleTypeId { get; set; }
    public virtual SoftwareLanguage SoftwareLanguage { get; set; } = null!;
    public virtual Instructor Instructor { get; set; } = null!;
    public virtual Company Company { get; set; } = null!;
    public virtual ModuleType ModuleType { get; set; } = null!;
    public virtual ICollection<CourseModule> CourseModules { get; set; } = null!;
    public virtual ICollection<StudentModule> StudentModules { get; set; } = null!;
    public virtual ICollection<ClassroomModule> ClassroomModules { get; set; } = null!;
    public virtual ICollection<ModuleSetCategory> ModuleSetCategorys { get; set; } = null!;

    public ModuleSet()
    {

    }

    public ModuleSet(Guid id, string name, string? educationType, string? courseLevel, string? topic, Guid? softwareLanguageId, Guid? instructorId, string? activityStatus, DateTime? startDate, DateTime? endDate, int? estimatedTime, string? imgUrl, Guid? companyId, Guid? moduleTypeId) : base(id)
    {
        Name = name;
        EducationType = educationType;
        CourseLevel = courseLevel;
        Topic = topic;
        SoftwareLanguageId = softwareLanguageId;
        InstructorId = instructorId;
        ActivityStatus = activityStatus;
        StartDate = startDate;
        EndDate = endDate;
        EstimatedTime = estimatedTime;
        ImgUrl = imgUrl;
        CompanyId = companyId;
        ModuleTypeId = moduleTypeId;
    }
}
