using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Country:Entity<Guid>
{
    public string Name { get; set; }
    public virtual ICollection<Student> Students { get; set; } = null!;
    public virtual ICollection<City> Cities { get; set; } = null!;
    public Country()
    {
        
    }
    public Country(Guid id,string name, ICollection<Student> students, ICollection<City> cities) : base(id)
    {
        Name = name;
        Students = students;
        Cities = cities;
    }
}
