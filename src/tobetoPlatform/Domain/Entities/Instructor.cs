using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Instructor: Entity<Guid>
{
    public string Name { get; set; }
    public string? ImgUrl { get; set; }
    public string? Description { get; set; }
    public virtual ICollection<CourseInstructor> CourseInstructors { get; set; } = null!;

    public Instructor()
    {
        
    }
    public Instructor(Guid id,string name, string? imgUrl, string? description) : base(id)
    {
        Name = name;
        ImgUrl = imgUrl;
        Description = description;
    }
}
