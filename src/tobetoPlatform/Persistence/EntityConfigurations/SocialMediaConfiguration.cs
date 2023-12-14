using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SocialMediaConfiguration : IEntityTypeConfiguration<SocialMedia>
{
    public void Configure(EntityTypeBuilder<SocialMedia> builder)
    {
        builder.ToTable("SocialMedias").HasKey(sm => sm.Id);

        builder.Property(sm => sm.Id).HasColumnName("Id").IsRequired();
        builder.Property(sm => sm.Name).HasColumnName("Name");
        builder.Property(sm => sm.Icon).HasColumnName("Icon");
        builder.Property(sm => sm.SocialMediaUrl).HasColumnName("SocialMediaUrl");
        builder.Property(sm => sm.StudentId).HasColumnName("StudentId");
        builder.Property(sm => sm.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(sm => sm.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(sm => sm.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: b => b.Name, name: "UK_SocialMedias_Name").IsUnique();
        builder.HasOne(b => b.Student);

        builder.HasQueryFilter(sm => !sm.DeletedDate.HasValue);
    }
}