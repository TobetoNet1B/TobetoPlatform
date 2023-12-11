using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Course: Entity<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImgUrl { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int EstimatedTime { get; set; }
    public int TimeSpent { get; set; }
    public int Duration { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
    public Guid CourseInstructorId { get; set; }
    public CourseInstructor CourseInstructors { get; set; }
    public List<Participant>  Participant { get; set; }
    public Guid LanguageId { get; set; }
    public Language CourseLanguage { get; set; }
    public string ActivityStatus { get; set; }

}
