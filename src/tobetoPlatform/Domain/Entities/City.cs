using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class City : Entity<Guid>
{
    public string Name { get; set; }
    public Guid CountryId { get; set; }
    public virtual Country Country { get; set; }
    public virtual ICollection<District> Districts { get; set; }
    public virtual ICollection<Experience> Experiences { get; set; } = null!;
    public virtual ICollection<Student> Students { get; set; } = null!;
    public City()
    {
        
    }
    public City(Guid id,string name, Guid countryId, Country country, ICollection<District> districts, ICollection<Experience> experiences, ICollection<Student> students) : base(id)
    {
        Name = name;
        CountryId = countryId;
        Country = country;
        Districts = districts;
        Experiences = experiences;
        Students = students;
    }
}
