using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Appeal: Entity<Guid>
{
    // Başvurular
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual ICollection<StudentAppeal> StudentAppeals { get; set; } = null!;

    public Appeal()
    {

    }
    public Appeal(Guid id,string name, string description) : base(id)
    {
        Name = name;
        Description = description;
    }
}
