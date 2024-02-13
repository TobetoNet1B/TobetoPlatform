using Core.Persistence.Repositories;


namespace Domain.Entities;
public class LessonTag:Entity<Guid>
{
    public Guid LessonId { get; set; }
    public Guid TagId { get; set; }
    public virtual Lesson Lesson { get; set; } = null!;
    public virtual Tag Tag { get; set; } = null!;

    public LessonTag()
    {
        
    }
    public LessonTag(Guid id, Guid lessonId, Guid tagId) : base(id)
    {
        LessonId = lessonId;
        TagId = tagId;
    }
}
