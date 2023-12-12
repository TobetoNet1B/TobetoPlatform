using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class ForeignLanguage : Entity<Guid>
    {
        public string Name { get; set; }
        public List<Course> Courses { get; set; }
        public Guid? StudentId { get; set; }
        public Student Student { get; set; }
        public ForeignLanguageLevel ForeignLanguageLevel { get; set; }
        public Guid ForeignLanguageLevelId { get; set; }
    }
}
