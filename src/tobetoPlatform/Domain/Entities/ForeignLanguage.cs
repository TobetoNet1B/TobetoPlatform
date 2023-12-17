using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class ForeignLanguage : Entity<Guid>
    {
        public string Name { get; set; }
        public virtual ICollection<StudentForeignLanguage> StudentForeignLanguages { get; set; } = null!;

        public ForeignLanguage()
        {
            
        }

        public ForeignLanguage(Guid id, string name) : base(id)
        {
            Name = name;
        }
    }
}
