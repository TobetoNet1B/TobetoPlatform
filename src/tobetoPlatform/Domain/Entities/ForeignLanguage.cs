using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class ForeignLanguage : Entity<Guid>
    {
        public string Name { get; set; }
        public Guid? StudentId { get; set; }
        public virtual Student? Student { get; set; } = null!;
        public Guid ForeignLanguageLevelId { get; set; }
        public virtual ForeignLanguageLevel? ForeignLanguageLevel { get; set; } = null!;
    }
}
