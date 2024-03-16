using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class TobetoContactConfiguration : IEntityTypeConfiguration<TobetoContact>
{
    public void Configure(EntityTypeBuilder<TobetoContact> builder)
    {
        builder.ToTable("TobetoContacts").HasKey(tc => tc.Id);

        builder.Property(tc => tc.Id).HasColumnName("Id").IsRequired();
        builder.Property(tc => tc.FullName).HasColumnName("FullName");
        builder.Property(tc => tc.Email).HasColumnName("Email");
        builder.Property(tc => tc.Message).HasColumnName("Message");
        builder.Property(tc => tc.IsReaded).HasColumnName("IsReaded");
        builder.Property(tc => tc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(tc => tc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(tc => tc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(tc => !tc.DeletedDate.HasValue);
    }
}