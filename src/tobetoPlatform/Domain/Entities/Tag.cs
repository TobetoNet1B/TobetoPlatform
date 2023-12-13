using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Tag: Entity<Guid>
{
    public string TagName { get; set; }
    public virtual ICollection<LessonTag> LessonTags { get; set; }
    public Tag()
    {
        
    }

    public Tag(Guid id,string tagName, ICollection<LessonTag> lessonTags):base(id)
    {
        TagName = tagName;
        LessonTags = lessonTags;
    }
}
