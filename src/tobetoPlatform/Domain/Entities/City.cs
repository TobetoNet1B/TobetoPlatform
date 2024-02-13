using Core.Persistence.Repositories;


namespace Domain.Entities;
public class City : Entity<Guid>
{
    public string Name { get; set; }
    public Guid CountryId { get; set; }
    public virtual Country Country { get; set; }
    public virtual ICollection<District> Districts { get; set; } = null!;
    public virtual ICollection<Experience> Experiences { get; set; } = null!;
    public virtual ICollection<Student> Students { get; set; } = null!;

    public City()
    {
        
    }
    public City(Guid id,string name, Guid countryId) : base(id)
    {
        Name = name;
        CountryId = countryId;
    }
}
