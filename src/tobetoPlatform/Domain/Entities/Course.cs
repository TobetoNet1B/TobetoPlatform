using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Course: Entity<Guid>
{
    public string Name { get; set; }
    public string? CourseTitle { get; set; }// Dijital gelişim, Profesyonel gelişim vb.
    public string? Description { get; set; }
    public int? CourseLevel { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int? EstimatedTime { get; set; }
    public string ActivityStatus { get; set; }
    public virtual ICollection<CourseCategory> CourseCategories { get; set; } = null!;
    public virtual ICollection<CourseInstructor> CourseInstructors { get; set; } = null!;
    public virtual ICollection<CourseModule> CourseModules { get; set; } = null!;
    public virtual ICollection<Lesson> Lessons { get; set; } = null!;
    public Course()
    {
        
    }
    public Course(Guid id,string name, string? courseTitle, string? description, int? courseLevel, DateTime startDate, DateTime endDate, int? estimatedTime, string activityStatus, ICollection<CourseCategory> courseCategories, ICollection<CourseInstructor> courseInstructors, ICollection<CourseModule> courseModules, ICollection<Lesson> lessons) : base(id)
    {
        Name = name;
        CourseTitle = courseTitle;
        Description = description;
        CourseLevel = courseLevel;
        StartDate = startDate;
        EndDate = endDate;
        EstimatedTime = estimatedTime;
        ActivityStatus = activityStatus;
        CourseCategories = courseCategories;
        CourseInstructors = courseInstructors;
        CourseModules = courseModules;
        Lessons = lessons;
    }
}
