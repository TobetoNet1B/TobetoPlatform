using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;
public class Instructor: Entity<Guid>
{
    public int UserId { get; set; }
    public string? ImgUrl { get; set; }
    public string? Description { get; set; }
    public virtual User User { get; set; } = null!;
    public virtual ICollection<ModuleSet> ModuleSets { get; set; } = null!;
    public virtual ICollection<CourseInstructor> CourseInstructors { get; set; } = null!;

    public Instructor()
    {
        
    }

    public Instructor(Guid Id, int userId, string? imgUrl, string? description):base(Id)
    {
        UserId = userId;
        ImgUrl = imgUrl;
        Description = description;
    }
}
