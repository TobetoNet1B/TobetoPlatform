using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class StudentModule:Entity<Guid>
{
    public Guid StudentId { get; set; }
    public virtual Student Student { get; set; } = null!;
    public Guid ModuleId { get; set; }
    public virtual Module Module { get; set; } = null!;
}
