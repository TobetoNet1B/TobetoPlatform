using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ForeignLanguageLevelConfiguration : IEntityTypeConfiguration<ForeignLanguageLevel>
{
    public void Configure(EntityTypeBuilder<ForeignLanguageLevel> builder)
    {
        builder.ToTable("ForeignLanguageLevels").HasKey(fll => fll.Id);

        builder.Property(fll => fll.Id).HasColumnName("Id").IsRequired();
        builder.Property(fll => fll.Name).HasColumnName("Name");
        builder.Property(fll => fll.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(fll => fll.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(fll => fll.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: b => b.Name, name: "UK_ForeignLanguageLevel_Name").IsUnique();
        builder.HasOne(b => b.ForeignLanguage);

        builder.HasQueryFilter(fll => !fll.DeletedDate.HasValue);
    }
}