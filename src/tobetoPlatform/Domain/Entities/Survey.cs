using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Survey: Entity<Guid>
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? SurveyUrl { get; set; }
    public Guid StudentId { get; set; }
    public virtual Student Student { get; set; } = null!;

    public Survey()
    {
        
    }
    public Survey(Guid id,string? title, string? description, string? surveyUrl, Guid studentId) : base(id)
    {
        Title = title;
        Description = description;
        SurveyUrl = surveyUrl;
        StudentId = studentId;
    }
}
