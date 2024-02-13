using Core.Persistence.Repositories;


namespace Domain.Entities;
public class CategoryOfCourse : Entity<Guid>
{
    public string Name { get; set; }
    public bool? IsActive { get; set; }
    public virtual ICollection<CourseCategory> CourseCategories { get; set; } = null!;
    public CategoryOfCourse()
    {
    }

    public CategoryOfCourse(string name, bool? isActive)
    {
        Name = name;
        IsActive = isActive;
    }
}
