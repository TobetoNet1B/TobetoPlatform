using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> builder)
    {
        builder.ToTable("Instructors").HasKey(i => i.Id);

        builder.Property(i => i.Id).HasColumnName("Id").IsRequired();
        builder.Property(i => i.Name).HasColumnName("Name");
        builder.Property(i => i.ImgUrl).HasColumnName("ImgUrl");
        builder.Property(i => i.Description).HasColumnName("Description");
        builder.Property(i => i.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(i => i.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(i => i.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: b => b.Name, name: "UK_Instructors_Name").IsUnique();
        builder.HasMany(b => b.CourseInstructors);

        builder.HasQueryFilter(i => !i.DeletedDate.HasValue);
    }
}