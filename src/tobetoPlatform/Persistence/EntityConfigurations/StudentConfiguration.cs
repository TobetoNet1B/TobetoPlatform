using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students").HasKey(s => s.Id);

        builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
        builder.Property(s => s.UserId).HasColumnName("UserId");
        builder.Property(s => s.IdentityNumber).HasColumnName("IdentityNumber");
        builder.Property(s => s.BirthDate).HasColumnName("BirthDate");
        builder.Property(s => s.PhoneNumber).HasColumnName("PhoneNumber");
        builder.Property(s => s.About).HasColumnName("About");
        builder.Property(s => s.Country).HasColumnName("Country");
        builder.Property(s => s.City).HasColumnName("City");
        builder.Property(s => s.District).HasColumnName("District");
        builder.Property(s => s.Address).HasColumnName("Address");
        builder.Property(s => s.ImgUrl).HasColumnName("ImgUrl");
        builder.Property(s => s.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(s => s.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(s => s.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: b => b.IdentityNumber, name: "UK_Students_Name").IsUnique();

        builder.HasOne(b => b.User);
        
        builder.HasMany(b => b.Abilities);
        builder.HasMany(b => b.Appeals);
        builder.HasMany(b => b.Surveys);
        builder.HasMany(b => b.CourseStudents);
        builder.HasMany(b => b.Certificates);
        builder.HasMany(b => b.SocialMedias);
        builder.HasMany(b => b.ForeignLanguages);
        builder.HasMany(b => b.Educations);
        builder.HasMany(b => b.StudentExams);
        builder.HasMany(b => b.Surveys);


        builder.HasQueryFilter(s => !s.DeletedDate.HasValue);
    }
}