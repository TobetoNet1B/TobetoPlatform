using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class StudentAppeal:Entity<Guid>
{
    public Guid AppealId { get; set; }
    public virtual Appeal Appeal { get; set; } = null!;
    public Guid StudentId { get; set; }
    public virtual Student Student { get; set; } = null!;
    public bool IsApproved { get; set; }
    public StudentAppeal()
    {
        
    }

    public StudentAppeal(Guid id,Guid appealId, Appeal appeal, Guid studentId, Student student, bool isApproved) : base(id)
    {
        AppealId = appealId;
        Appeal = appeal;
        StudentId = studentId;
        Student = student;
        IsApproved = isApproved;
    }
}
