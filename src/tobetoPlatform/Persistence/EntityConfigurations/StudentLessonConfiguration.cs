using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class StudentLessonConfiguration : IEntityTypeConfiguration<StudentLesson>
{
    public void Configure(EntityTypeBuilder<StudentLesson> builder)
    {
        builder.ToTable("StudentLessons").HasKey(sl => sl.Id);

        builder.Property(sl => sl.Id).HasColumnName("Id").IsRequired();
        builder.Property(sl => sl.StudentId).HasColumnName("StudentId");
        builder.Property(sl => sl.LessonId).HasColumnName("LessonId");
        builder.Property(sl => sl.IsLiked).HasColumnName("IsLiked");
        builder.Property(sl => sl.IsWatched).HasColumnName("IsWatched");
        builder.Property(sl => sl.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(sl => sl.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(sl => sl.DeletedDate).HasColumnName("DeletedDate");


        builder.HasOne(sl => sl.Student);
        builder.HasOne(sl => sl.Lesson);


        builder.HasQueryFilter(sl => !sl.DeletedDate.HasValue);
    }
}