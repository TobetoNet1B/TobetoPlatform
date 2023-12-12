using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SurveyConfiguration : IEntityTypeConfiguration<Survey>
{
    public void Configure(EntityTypeBuilder<Survey> builder)
    {
        builder.ToTable("Surveys").HasKey(s => s.Id);

        builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
        builder.Property(s => s.Title).HasColumnName("Title");
        builder.Property(s => s.Description).HasColumnName("Description");
        builder.Property(s => s.StudentId).HasColumnName("StudentId");
        builder.Property(s => s.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(s => s.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(s => s.DeletedDate).HasColumnName("DeletedDate");


        builder.HasIndex(indexExpression: b => b.Title, name: "UK_Surveys_Name").IsUnique();

        builder.HasOne(b => b.Student);


        builder.HasQueryFilter(s => !s.DeletedDate.HasValue);
    }
}