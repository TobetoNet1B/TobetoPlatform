using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Classroom : Entity<Guid>
{
    public string Name { get; set; }
    public int ClassSize { get; set; }
    public virtual ICollection<StudentClassroom> StudentClassrooms { get; set; } = null!;

    public Classroom()
    {
    }

    public Classroom(Guid id, string name, int classSize):base(id)
    {
        Name = name;
        ClassSize = classSize;
    }
}
