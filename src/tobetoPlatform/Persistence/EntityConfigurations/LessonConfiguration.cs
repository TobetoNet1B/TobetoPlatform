using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.ToTable("Lessons").HasKey(l => l.Id);

        builder.Property(l => l.Id).HasColumnName("Id").IsRequired();
        builder.Property(l => l.Name).HasColumnName("Name");
        builder.Property(l => l.Description).HasColumnName("Description");
        builder.Property(l => l.LessonUrl).HasColumnName("LessonUrl");
        builder.Property(l => l.ImgUrl).HasColumnName("ImgUrl");
        builder.Property(l => l.LessonType).HasColumnName("LessonType");
        builder.Property(l => l.Duration).HasColumnName("Duration");
        builder.Property(l => l.CourseId).HasColumnName("CourseId");
        builder.Property(l => l.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(l => l.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(l => l.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: b => b.Name, name: "UK_Lessons_Name").IsUnique();
        builder.HasOne(b => b.Course);
        builder.HasMany(b => b.LessonTags);

        builder.HasQueryFilter(l => !l.DeletedDate.HasValue);
    }
}