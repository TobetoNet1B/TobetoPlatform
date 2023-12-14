using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class StudentAppealConfiguration : IEntityTypeConfiguration<StudentAppeal>
{
    public void Configure(EntityTypeBuilder<StudentAppeal> builder)
    {
        builder.ToTable("StudentAppeals").HasKey(sa => sa.Id);

        builder.Property(sa => sa.Id).HasColumnName("Id").IsRequired();
        builder.Property(sa => sa.AppealId).HasColumnName("AppealId");
        builder.Property(sa => sa.StudentId).HasColumnName("StudentId");
        builder.Property(sa => sa.IsApproved).HasColumnName("IsApproved");
        builder.Property(sa => sa.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(sa => sa.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(sa => sa.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(b => b.Student);
        builder.HasOne(b => b.Appeal);

        builder.HasQueryFilter(sa => !sa.DeletedDate.HasValue);
    }
}