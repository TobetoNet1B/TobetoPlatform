﻿using Core.Persistence.Repositories;

namespace Domain.Entities;
public class CourseInstructor : Entity<Guid>
{
    public Guid InstructorId { get; set; }
    public Instructor Instructor { get; set; }
    public Guid CourseId { get; set; }
    public Course Course { get; set; }
}
