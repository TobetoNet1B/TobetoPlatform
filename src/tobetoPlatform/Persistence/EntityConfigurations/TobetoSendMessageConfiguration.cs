using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class TobetoSendMessageConfiguration : IEntityTypeConfiguration<TobetoSendMessage>
{
    public void Configure(EntityTypeBuilder<TobetoSendMessage> builder)
    {
        builder.ToTable("TobetoSendMessages").HasKey(tsm => tsm.Id);

        builder.Property(tsm => tsm.Id).HasColumnName("Id").IsRequired();
        builder.Property(tsm => tsm.Subject).HasColumnName("Subject");
        builder.Property(tsm => tsm.Content).HasColumnName("Content");
        builder.Property(tsm => tsm.SenderName).HasColumnName("SenderName");
        builder.Property(tsm => tsm.SenderEmail).HasColumnName("SenderEmail");
        builder.Property(tsm => tsm.ReceiverName).HasColumnName("ReceiverName");
        builder.Property(tsm => tsm.ReceiverEmail).HasColumnName("ReceiverEmail");
        builder.Property(tsm => tsm.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(tsm => tsm.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(tsm => tsm.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(tsm => !tsm.DeletedDate.HasValue);
    }
}