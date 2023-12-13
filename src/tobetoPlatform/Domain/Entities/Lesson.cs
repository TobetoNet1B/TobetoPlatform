using Core.Persistence.Repositories;
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
    public string LessonType { get; set; }
    public Guid CourseId { get; set; }
    public virtual Course? Course { get; set; } = null!;
}
