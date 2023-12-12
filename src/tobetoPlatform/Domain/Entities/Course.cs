using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Course: Entity<Guid>
{
    public string Name { get; set; }
    public string? CourseTitle { get; set; }// Dijital gelişim, Profesyonel gelişim vb.
    public string? Description { get; set; }
    public int? CourseLevel { get; set; }
    public string? ImgUrl { get; set; }
    public string SoftwareLanguage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int? EstimatedTime { get; set; }
    public int? TimeSpent { get; set; }
    public int? Duration { get; set; }
    public List<CourseParticipant> CourseParticipants { get; set; }
    public List<CourseCategory> CourseCategories { get; set; }
    public List<CourseInstructor> CourseInstructors { get; set; }
    public string ActivityStatus { get; set; }

}
