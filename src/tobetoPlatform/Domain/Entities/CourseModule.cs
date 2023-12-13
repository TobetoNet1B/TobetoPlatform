using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class CourseModule:Entity<Guid>
{
    public Guid CourseId { get; set; }
    public virtual Course Course { get; set; } = null!;
    public Guid ModuleId { get; set; }
    public virtual Module Module { get; set; } = null!;
}
