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
        builder.Property(ms => ms.EducationType).HasColumnName("EducationType");
        builder.Property(ms => ms.CourseLevel).HasColumnName("CourseLevel");
        builder.Property(ms => ms.Topic).HasColumnName("Topic");
        builder.Property(ms => ms.SoftwareLanguageId).HasColumnName("SoftwareLanguageId");
        builder.Property(ms => ms.InstructorId).HasColumnName("InstructorId");
        builder.Property(ms => ms.ActivityStatus).HasColumnName("ActivityStatus");
        builder.Property(ms => ms.StartDate).HasColumnName("StartDate");
        builder.Property(ms => ms.EndDate).HasColumnName("EndDate");
        builder.Property(ms => ms.EstimatedTime).HasColumnName("EstimatedTime");
        builder.Property(ms => ms.ImgUrl).HasColumnName("ImgUrl");
        builder.Property(ms => ms.CompanyId).HasColumnName("CompanyId");
        builder.Property(ms => ms.ModuleTypeId).HasColumnName("ModuleTypeId");
        builder.Property(ms => ms.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ms => ms.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ms => ms.DeletedDate).HasColumnName("DeletedDate");


        builder.HasIndex(indexExpression: b => b.Name, name: "UK_ModuleSets_Name").IsUnique();

        builder.HasOne(b => b.SoftwareLanguage);
        builder.HasOne(b => b.Instructor).WithMany(i => i!.ModuleSets);
        builder.HasOne(b => b.Company);
        builder.HasOne(b => b.ModuleType);
        builder.HasMany(b => b.CourseModules);
        builder.HasMany(b => b.StudentModules).WithOne(i=>i!.ModuleSet);
        builder.HasMany(b => b.ClassroomModules);
        builder.HasMany(b => b.ModuleSetCategorys);

        builder.HasQueryFilter(ms => !ms.DeletedDate.HasValue);
    }
}