using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class ForeignLanguage : Entity<Guid>
    {
        public string Name { get; set; }
        public Guid ForeignLanguageLevelId { get; set; }
        public Guid StudentId { get; set; }
        public virtual ForeignLanguageLevel ForeignLanguageLevel { get; set; } = null!;
        public virtual Student Student { get; set; }

        public ForeignLanguage()
        {
            
        }

        public ForeignLanguage(Guid id, string name, Guid foreignLanguageLevelId, Guid studentId) : base(id)
        {
            Name = name;
            ForeignLanguageLevelId = foreignLanguageLevelId;
            StudentId = studentId;
        }
    }
}
