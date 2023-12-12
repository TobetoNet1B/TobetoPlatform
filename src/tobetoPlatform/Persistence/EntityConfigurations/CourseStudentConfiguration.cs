using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CourseStudentConfiguration : IEntityTypeConfiguration<CourseStudent>
{
    public void Configure(EntityTypeBuilder<CourseStudent> builder)
    {
        builder.ToTable("CourseStudents").HasKey(cs => cs.Id);

        builder.Property(cs => cs.Id).HasColumnName("Id").IsRequired();
        builder.Property(cs => cs.CourseId).HasColumnName("CourseId");
        builder.Property(cs => cs.StudentId).HasColumnName("StudentId");
        builder.Property(cs => cs.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(cs => cs.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(cs => cs.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(cs => !cs.DeletedDate.HasValue);
    }
}