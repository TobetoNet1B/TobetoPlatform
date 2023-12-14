using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class StudentExamConfiguration : IEntityTypeConfiguration<StudentExam>
{
    public void Configure(EntityTypeBuilder<StudentExam> builder)
    {
        builder.ToTable("StudentExams").HasKey(se => se.Id);

        builder.Property(se => se.Id).HasColumnName("Id").IsRequired();
        builder.Property(se => se.StudentId).HasColumnName("StudentId");
        builder.Property(se => se.ExamId).HasColumnName("ExamId");
        builder.Property(se => se.IsAttended).HasColumnName("IsAttended");
        builder.Property(se => se.CountOfTrue).HasColumnName("CountOfTrue");
        builder.Property(se => se.CountOfFalse).HasColumnName("CountOfFalse");
        builder.Property(se => se.CountOfEmpty).HasColumnName("CountOfEmpty");
        builder.Property(se => se.Score).HasColumnName("Score");
        builder.Property(se => se.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(se => se.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(se => se.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(se => !se.DeletedDate.HasValue);
    }
}