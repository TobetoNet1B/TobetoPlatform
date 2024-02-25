using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class StudentModuleConfiguration : IEntityTypeConfiguration<StudentModule>
{
    public void Configure(EntityTypeBuilder<StudentModule> builder)
    {
        builder.ToTable("StudentModules").HasKey(sm => sm.Id);

        builder.Property(sm => sm.Id).HasColumnName("Id").IsRequired();
        builder.Property(sm => sm.StudentId).HasColumnName("StudentId");
        builder.Property(sm => sm.ModuleSetId).HasColumnName("ModuleSetId");
        builder.Property(sm => sm.TimeSpent).HasColumnName("TimeSpent");
        builder.Property(sm => sm.IsLiked).HasColumnName("IsLiked");
        builder.Property(sm => sm.IsFav).HasColumnName("IsFav");
        builder.Property(sm => sm.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(sm => sm.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(sm => sm.DeletedDate).HasColumnName("DeletedDate");


        builder.HasOne(b => b.Student).WithMany(m => m.StudentModules).HasForeignKey(sm => sm.StudentId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(b => b.ModuleSet).WithMany(m => m.StudentModules).HasForeignKey(sm => sm.ModuleSetId).OnDelete(DeleteBehavior.Restrict);

        builder.HasQueryFilter(sm => !sm.DeletedDate.HasValue);
    }
}