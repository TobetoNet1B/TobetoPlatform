﻿using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Lesson:Entity<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string LessonUrl { get; set; }
    public string? ImgUrl { get; set; }
    public string LessonType { get; set; }
    public int? Duration { get; set; }
    public Guid CourseId { get; set; }
    public virtual Course Course { get; set; } = null!;
    public virtual ICollection<LessonTag> LessonTags { get; set; } = null!;

    public Lesson()
    {
        
    }
    public Lesson(Guid id,string name, string description, string lessonUrl, string? imgUrl, string lessonType, int? duration, Guid courseId) : base(id)
    {
        Name = name;
        Description = description;
        LessonUrl = lessonUrl;
        ImgUrl = imgUrl;
        LessonType = lessonType;
        Duration = duration;
        CourseId = courseId;
    }
}
