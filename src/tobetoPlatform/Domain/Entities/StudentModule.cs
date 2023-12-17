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
    public Guid ModuleId { get; set; }
    public int? TimeSpent { get; set; }
    public virtual Student Student { get; set; } = null!;
    public virtual ModuleSet Module { get; set; } = null!;

    public StudentModule()
    {
        
    }
    public StudentModule(Guid id,Guid studentId, Guid moduleId, int? timeSpent) : base(id)
    {
        StudentId = studentId;
        ModuleId = moduleId;
        TimeSpent = timeSpent;
    }
}
