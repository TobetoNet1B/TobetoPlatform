using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CategoryOfModuleSetConfiguration : IEntityTypeConfiguration<CategoryOfModuleSet>
{
    public void Configure(EntityTypeBuilder<CategoryOfModuleSet> builder)
    {
        builder.ToTable("CategoryOfModuleSets").HasKey(coms => coms.Id);

        builder.Property(coms => coms.Id).HasColumnName("Id").IsRequired();
        builder.Property(coms => coms.Name).HasColumnName("Name");
        builder.Property(coms => coms.IsActive).HasColumnName("IsActive");
        builder.Property(coms => coms.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(coms => coms.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(coms => coms.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: b => b.Name, name: "UK_CategoryOfModuleSets_Name").IsUnique();

        builder.HasMany(b => b.ModuleSetCategories);

        builder.HasQueryFilter(coms => !coms.DeletedDate.HasValue);
    }
}