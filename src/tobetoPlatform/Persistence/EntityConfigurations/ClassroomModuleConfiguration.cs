using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ClassroomModuleConfiguration : IEntityTypeConfiguration<ClassroomModule>
{
    public void Configure(EntityTypeBuilder<ClassroomModule> builder)
    {
        builder.ToTable("ClassroomModules").HasKey(cm => cm.Id);

        builder.Property(cm => cm.Id).HasColumnName("Id").IsRequired();
        builder.Property(cm => cm.ClassroomId).HasColumnName("ClassroomId");
        builder.Property(cm => cm.ModuleSetId).HasColumnName("ModuleSetId");
        builder.Property(cm => cm.ClassroomStartDate).HasColumnName("ClassroomStartDate");
        builder.Property(cm => cm.ClassroomEndDate).HasColumnName("ClassroomEndDate");
        builder.Property(cm => cm.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(cm => cm.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(cm => cm.DeletedDate).HasColumnName("DeletedDate");


        builder.HasOne(b => b.Classroom);
        builder.HasOne(b => b.ModuleSet);

        builder.HasQueryFilter(cm => !cm.DeletedDate.HasValue);
    }
}