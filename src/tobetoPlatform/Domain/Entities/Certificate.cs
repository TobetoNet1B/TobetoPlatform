using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Certificate: Entity<Guid>
{
    public string Name { get; set; }
    public string FileType { get; set; }
    public Guid StudentId { get; set; }
    public virtual Student? Student { get; set; } = null!;
    public Certificate()
    {
        
    }
    public Certificate(Guid id,string name, string fileType, Guid studentId, Student? student) : base(id)
    {
        Name = name;
        FileType = fileType;
        StudentId = studentId;
        Student = student;
    }
}
