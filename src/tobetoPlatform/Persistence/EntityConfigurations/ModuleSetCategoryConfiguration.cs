using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ModuleSetCategoryConfiguration : IEntityTypeConfiguration<ModuleSetCategory>
{
    public void Configure(EntityTypeBuilder<ModuleSetCategory> builder)
    {
        builder.ToTable("ModuleSetCategories").HasKey(msc => msc.Id);

        builder.Property(msc => msc.Id).HasColumnName("Id").IsRequired();
        builder.Property(msc => msc.ModuleSetId).HasColumnName("ModuleSetId");
        builder.Property(msc => msc.CategoryOfModuleSetId).HasColumnName("CategoryOfModuleSetId");
        builder.Property(msc => msc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(msc => msc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(msc => msc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(b => b.ModuleSet);
        builder.HasOne(b => b.CategoryOfModuleSet);

        builder.HasQueryFilter(msc => !msc.DeletedDate.HasValue);
    }
}