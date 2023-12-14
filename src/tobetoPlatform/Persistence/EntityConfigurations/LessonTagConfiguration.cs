using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class LessonTagConfiguration : IEntityTypeConfiguration<LessonTag>
{
    public void Configure(EntityTypeBuilder<LessonTag> builder)
    {
        builder.ToTable("LessonTags").HasKey(lt => lt.Id);

        builder.Property(lt => lt.Id).HasColumnName("Id").IsRequired();
        builder.Property(lt => lt.LessonId).HasColumnName("LessonId");
        builder.Property(lt => lt.TagId).HasColumnName("TagId");
        builder.Property(lt => lt.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(lt => lt.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(lt => lt.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(b => b.Lesson);
        builder.HasOne(b => b.Tag);

        builder.HasQueryFilter(lt => !lt.DeletedDate.HasValue);
    }
}