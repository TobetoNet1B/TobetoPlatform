using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Course: Entity<Guid>
{
    public string Name { get; set; }
    public virtual ICollection<CourseModule> CourseModules { get; set; } = null!;
    public virtual ICollection<Lesson> Lessons { get; set; } = null!;
    public virtual ICollection<CourseCategory> CourseCategories { get; set; } = null!;
    public virtual ICollection<CourseInstructor> CourseInstructors { get; set; } = null!;

    public Course()
    {
        
    }
    public Course(Guid id,string name) : base(id)
    {
        Name = name;
    }
}
