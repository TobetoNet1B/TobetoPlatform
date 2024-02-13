using Core.Persistence.Repositories;


namespace Domain.Entities;
public class Country:Entity<Guid>
{
    public string Name { get; set; }
    public virtual ICollection<Student> Students { get; set; } = null!;
    public virtual ICollection<City> Cities { get; set; } = null!;

    public Country()
    {
        
    }
    public Country(Guid id ,string name) : base(id)
    {
        Name = name;
    }
}
