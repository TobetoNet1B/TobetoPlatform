using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("Courses").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.Name).HasColumnName("Name");
        builder.Property(c => c.CourseTitle).HasColumnName("CourseTitle");
        builder.Property(c => c.Description).HasColumnName("Description");
        builder.Property(c => c.CourseLevel).HasColumnName("CourseLevel");
        builder.Property(c => c.StartDate).HasColumnName("StartDate");
        builder.Property(c => c.EndDate).HasColumnName("EndDate");
        builder.Property(c => c.EstimatedTime).HasColumnName("EstimatedTime");
        builder.Property(c => c.ActivityStatus).HasColumnName("ActivityStatus");
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: b => b.Name, name: "UK_Courses_Name").IsUnique();
        builder.HasMany(b => b.CourseCategories);
        builder.HasMany(b => b.CourseInstructors);
        builder.HasMany(b => b.CourseModules);
        builder.HasMany(b => b.Lessons);

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
    }
}