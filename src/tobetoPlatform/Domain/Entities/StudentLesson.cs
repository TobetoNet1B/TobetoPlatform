using Core.Persistence.Repositories;

namespace Domain.Entities;
public class StudentLesson : Entity<Guid>
{
    public Guid? StudentId { get; set; }
    public Guid? LessonId { get; set; }
    public bool? IsLiked { get; set; }
    public bool? IsWatched { get; set; }
    public virtual Student Student { get; set; } = null!;
    public virtual Lesson Lesson { get; set; } = null!;

    public StudentLesson()
    {
    }

    public StudentLesson(Guid id, Guid? studentId, Guid? lessonId, bool? isLiked, bool? isWatched) : base(id)
    {
        StudentId = studentId;
        LessonId = lessonId;
        IsLiked = isLiked;
        IsWatched = isWatched;
    }
}
