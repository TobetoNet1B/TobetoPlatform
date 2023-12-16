using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class StudentForeignLanguageConfiguration : IEntityTypeConfiguration<StudentForeignLanguage>
{
    public void Configure(EntityTypeBuilder<StudentForeignLanguage> builder)
    {
        builder.ToTable("StudentForeignLanguages").HasKey(sfl => sfl.Id);

        builder.Property(sfl => sfl.Id).HasColumnName("Id").IsRequired();
        builder.Property(sfl => sfl.StudentId).HasColumnName("StudentId");
        builder.Property(sfl => sfl.ForeignLanguageId).HasColumnName("ForeignLanguageId");
        builder.Property(sfl => sfl.ForeignLanguageLevelId).HasColumnName("ForeignLanguageLevelId");
        builder.Property(sfl => sfl.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(sfl => sfl.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(sfl => sfl.DeletedDate).HasColumnName("DeletedDate");
        builder.HasOne(b => b.Student);
        builder.HasOne(b => b.ForeignLanguage);
        builder.HasOne(b => b.ForeignLanguageLevel);
        builder.HasQueryFilter(sfl => !sfl.DeletedDate.HasValue);
    }
}