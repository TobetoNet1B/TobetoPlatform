using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class LessonTag:Entity<Guid>
{
    public Guid LessonId { get; set; }
    public virtual Lesson Lesson { get; set; } = null!;
    public Guid TagId { get; set; }
    public virtual Tag Tag { get; set; } = null!;
    public LessonTag()
    {
        
    }

    public LessonTag(Guid id,Guid lessonId, Lesson lesson, Guid tagId, Tag tag) : base(id)
    {
        LessonId = lessonId;
        Lesson = lesson;
        TagId = tagId;
        Tag = tag;
    }
}
