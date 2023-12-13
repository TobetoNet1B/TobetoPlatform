using Core.Persistence.Repositories;

namespace Domain.Entities;
public class CourseCategory: Entity<Guid>
{
    public Guid CourseId { get; set; }
    public virtual Course Course { get; set; } = null!;
    public Guid CategoryId { get; set; }
    public virtual Category Category { get; set; } = null!;
    public CourseCategory()
    {
        
    }

    public CourseCategory(Guid id,Guid courseId, Course course, Guid categoryId, Category category) : base(id)
    {
        CourseId = courseId;
        Course = course;
        CategoryId = categoryId;
        Category = category;
    }
}
