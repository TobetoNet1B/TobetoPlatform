using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ModuleTypeConfiguration : IEntityTypeConfiguration<ModuleType>
{
    public void Configure(EntityTypeBuilder<ModuleType> builder)
    {
        builder.ToTable("ModuleTypes").HasKey(mt => mt.Id);

        builder.Property(mt => mt.Id).HasColumnName("Id").IsRequired();
        builder.Property(mt => mt.Name).HasColumnName("Name");
        builder.Property(mt => mt.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(mt => mt.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(mt => mt.DeletedDate).HasColumnName("DeletedDate");


        builder.HasIndex(indexExpression: b => b.Name, name: "UK_ModuleTypes_Name").IsUnique();

        builder.HasMany(b => b.ModuleSets);

        builder.HasQueryFilter(mt => !mt.DeletedDate.HasValue);
    }
}