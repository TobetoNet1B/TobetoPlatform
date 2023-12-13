using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Module:Entity<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImgUrl { get; set; }
    public Guid CategoryId { get; set; }
    public virtual Category? Category { get; set; } = null!;
    public Guid CompanyId { get; set; }
    public virtual Company? Company{ get; set; } = null!;
    public virtual ICollection<CourseModule> CourseModules { get; set; } = null!;
    public virtual ICollection<StudentModule> StudentModules { get; set; } = null!;
}
