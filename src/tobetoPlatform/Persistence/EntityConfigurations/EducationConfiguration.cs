using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class EducationConfiguration : IEntityTypeConfiguration<Education>
{
    public void Configure(EntityTypeBuilder<Education> builder)
    {
        builder.ToTable("Educations").HasKey(e => e.Id);

        builder.Property(e => e.Id).HasColumnName("Id").IsRequired();
        builder.Property(e => e.University).HasColumnName("University");
        builder.Property(e => e.Department).HasColumnName("Department");
        builder.Property(e => e.Graduation).HasColumnName("Graduation");
        builder.Property(e => e.StartDate).HasColumnName("StartDate");
        builder.Property(e => e.EndDate).HasColumnName("EndDate");
        builder.Property(e => e.IsContinueUniversity).HasColumnName("IsContinueUniversity");
        builder.Property(e => e.StudentId).HasColumnName("StudentId");
        builder.Property(e => e.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(e => e.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(e => e.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(e => !e.DeletedDate.HasValue);
    }
}