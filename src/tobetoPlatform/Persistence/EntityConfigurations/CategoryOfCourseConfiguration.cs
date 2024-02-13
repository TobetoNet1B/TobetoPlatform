using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CategoryOfCourseConfiguration : IEntityTypeConfiguration<CategoryOfCourse>
{
    public void Configure(EntityTypeBuilder<CategoryOfCourse> builder)
    {
        builder.ToTable("CategoryOfCourses").HasKey(coc => coc.Id);

        builder.Property(coc => coc.Id).HasColumnName("Id").IsRequired();
        builder.Property(coc => coc.Name).HasColumnName("Name");
        builder.Property(coc => coc.IsActive).HasColumnName("IsActive");
        builder.Property(coc => coc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(coc => coc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(coc => coc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: b => b.Name, name: "UK_CategoryOfCourses_Name").IsUnique();

        builder.HasMany(b => b.CourseCategories);

        builder.HasQueryFilter(coc => !coc.DeletedDate.HasValue);
    }
}