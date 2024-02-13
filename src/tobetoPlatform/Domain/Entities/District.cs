using Core.Persistence.Repositories;


namespace Domain.Entities;
public class District:Entity<Guid>
{
    public string Name { get; set; }
    public Guid? CityId { get; set; }
    public virtual City City { get; set; }
    public virtual ICollection<Student> Students { get; set; }

    public District()
    {
        
    }
    public District(Guid id,string name, Guid? cityId) : base(id)
    {
        Name = name;
        CityId = cityId;
    }
}
