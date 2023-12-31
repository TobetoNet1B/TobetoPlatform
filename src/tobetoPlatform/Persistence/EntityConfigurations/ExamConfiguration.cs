using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ExamConfiguration : IEntityTypeConfiguration<Exam>
{
    public void Configure(EntityTypeBuilder<Exam> builder)
    {
        builder.ToTable("Exams").HasKey(e => e.Id);

        builder.Property(e => e.Id).HasColumnName("Id").IsRequired();
        builder.Property(e => e.Name).HasColumnName("Name");
        builder.Property(e => e.Description).HasColumnName("Description");
        builder.Property(e => e.Time).HasColumnName("Time");
        builder.Property(e => e.QuestionCount).HasColumnName("QuestionCount");
        builder.Property(e => e.QuestionType).HasColumnName("QuestionType");
        builder.Property(e => e.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(e => e.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(e => e.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: b => b.Name, name: "UK_Exams_Name").IsUnique();
        builder.HasMany(b => b.StudentExams);

        builder.HasQueryFilter(e => !e.DeletedDate.HasValue);
    }
}