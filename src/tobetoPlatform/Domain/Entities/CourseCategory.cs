using Core.Persistence.Repositories;

namespace Domain.Entities;
public class CourseCategory: Entity<Guid>
{
    public Guid CourseId { get; set; }
    public Guid CategoryOfCourseId { get; set; }
    public virtual Course Course { get; set; } = null!;
    public virtual CategoryOfCourse CategoryOfCourse { get; set; } = null!;

    public CourseCategory()
    {
        
    }
    public CourseCategory(Guid id, Guid courseId, Guid categoryOfCourseId) : base(id)
    {
        CourseId = courseId;
        CategoryOfCourseId = categoryOfCourseId;
    }
}
