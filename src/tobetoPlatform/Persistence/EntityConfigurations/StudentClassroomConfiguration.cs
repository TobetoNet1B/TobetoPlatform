using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class StudentClassroomConfiguration : IEntityTypeConfiguration<StudentClassroom>
{
    public void Configure(EntityTypeBuilder<StudentClassroom> builder)
    {
        builder.ToTable("StudentClassrooms").HasKey(sc => sc.Id);

        builder.Property(sc => sc.Id).HasColumnName("Id").IsRequired();
        builder.Property(sc => sc.StudentId).HasColumnName("StudentId");
        builder.Property(sc => sc.ClassroomId).HasColumnName("ClassroomId");
        builder.Property(sc => sc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(sc => sc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(sc => sc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(b => b.Student);
        builder.HasOne(b => b.Classroom);

        builder.HasQueryFilter(sc => !sc.DeletedDate.HasValue);
    }
}