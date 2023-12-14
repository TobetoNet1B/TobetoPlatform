using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CourseModuleConfiguration : IEntityTypeConfiguration<CourseModule>
{
    public void Configure(EntityTypeBuilder<CourseModule> builder)
    {
        builder.ToTable("CourseModules").HasKey(cm => cm.Id);

        builder.Property(cm => cm.Id).HasColumnName("Id").IsRequired();
        builder.Property(cm => cm.CourseId).HasColumnName("CourseId");
        builder.Property(cm => cm.ModuleId).HasColumnName("ModuleId");
        builder.Property(cm => cm.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(cm => cm.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(cm => cm.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(cm => !cm.DeletedDate.HasValue);
    }
}