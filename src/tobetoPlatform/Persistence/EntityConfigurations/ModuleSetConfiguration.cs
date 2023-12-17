using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ModuleSetConfiguration : IEntityTypeConfiguration<ModuleSet>
{
    public void Configure(EntityTypeBuilder<ModuleSet> builder)
    {
        builder.ToTable("ModuleSets").HasKey(ms => ms.Id);

        builder.Property(ms => ms.Id).HasColumnName("Id").IsRequired();
        builder.Property(ms => ms.Name).HasColumnName("Name");
        builder.Property(ms => ms.Description).HasColumnName("Description");
        builder.Property(ms => ms.ImgUrl).HasColumnName("ImgUrl");
        builder.Property(ms => ms.CategoryId).HasColumnName("CategoryId");
        builder.Property(ms => ms.SoftwareLanguageId).HasColumnName("SoftwareLanguageId");
        builder.Property(ms => ms.CompanyId).HasColumnName("CompanyId");
        builder.Property(ms => ms.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ms => ms.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ms => ms.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: b => b.Name, name: "UK_ModuleSets_Name").IsUnique();
        builder.HasOne(b => b.Category);
        builder.HasOne(b => b.Company);
        builder.HasOne(b => b.SoftwareLanguage);
        builder.HasMany(b => b.CourseModules);
        builder.HasMany(b => b.StudentModules);

        builder.HasQueryFilter(ms => !ms.DeletedDate.HasValue);
    }
}