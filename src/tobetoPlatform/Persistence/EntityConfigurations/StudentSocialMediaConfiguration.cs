using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class StudentSocialMediaConfiguration : IEntityTypeConfiguration<StudentSocialMedia>
{
    public void Configure(EntityTypeBuilder<StudentSocialMedia> builder)
    {
        builder.ToTable("StudentSocialMedias").HasKey(ssm => ssm.Id);

        builder.Property(ssm => ssm.Id).HasColumnName("Id").IsRequired();
        builder.Property(ssm => ssm.StudentId).HasColumnName("StudentId");
        builder.Property(ssm => ssm.SocialMediaId).HasColumnName("SocialMediaId");
        builder.Property(ssm => ssm.SocialMediaUrl).HasColumnName("SocialMediaUrl");
        builder.Property(ssm => ssm.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ssm => ssm.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ssm => ssm.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(b => b.Student);
        builder.HasOne(b => b.SocialMedia);


        builder.HasQueryFilter(ssm => !ssm.DeletedDate.HasValue);
    }
}