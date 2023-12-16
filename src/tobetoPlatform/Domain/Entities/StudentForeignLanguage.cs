using Core.Persistence.Repositories;

namespace Domain.Entities;
public class StudentForeignLanguage:Entity<Guid>
{
    public  Guid StudentId { get; set; }
    public  Guid ForeignLanguageId { get; set; }
    public  Guid ForeignLanguageLevelId { get; set; }
    public virtual Student Student { get; set; }
    public virtual ForeignLanguage ForeignLanguage { get; set; }
    public virtual ForeignLanguageLevel ForeignLanguageLevel { get; set; }
    public StudentForeignLanguage()
    {
        
    }

    public StudentForeignLanguage(Guid id,Guid studentId, Guid foreignLanguageId, Guid foreignLanguageLevelId):base(id)
    {
        StudentId = studentId;
        ForeignLanguageId = foreignLanguageId;
        ForeignLanguageLevelId = foreignLanguageLevelId;
    }
}
