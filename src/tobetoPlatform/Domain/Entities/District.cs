using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
