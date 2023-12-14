using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SoftwareLanguageConfiguration : IEntityTypeConfiguration<SoftwareLanguage>
{
    public void Configure(EntityTypeBuilder<SoftwareLanguage> builder)
    {
        builder.ToTable("SoftwareLanguages").HasKey(sl => sl.Id);

        builder.Property(sl => sl.Id).HasColumnName("Id").IsRequired();
        builder.Property(sl => sl.Name).HasColumnName("Name");
        builder.Property(sl => sl.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(sl => sl.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(sl => sl.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(sl => !sl.DeletedDate.HasValue);
    }
}