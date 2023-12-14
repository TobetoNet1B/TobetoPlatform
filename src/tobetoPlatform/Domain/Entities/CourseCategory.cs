using Core.Persistence.Repositories;

namespace Domain.Entities;
public class CourseCategory: Entity<Guid>
{
    public Guid CourseId { get; set; }
    public Guid CategoryId { get; set; }
    public virtual Course Course { get; set; } = null!;
    public virtual Category Category { get; set; } = null!;

    public CourseCategory()
    {
        
    }
    public CourseCategory(Guid id, Guid courseId, Guid categoryId) : base(id)
    {
        CourseId = courseId;
        CategoryId = categoryId;
    }
}
