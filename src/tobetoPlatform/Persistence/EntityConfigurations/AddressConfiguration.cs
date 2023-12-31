using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Addresses").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.CountryId).HasColumnName("CountryId");
        builder.Property(a => a.CityId).HasColumnName("CityId");
        builder.Property(a => a.DistrictId).HasColumnName("DistrictId");
        builder.Property(a => a.StudentId).HasColumnName("StudentId");
        builder.Property(a => a.AddressDetails).HasColumnName("AddressDetails");
        builder.Property(a => a.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(a => a.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(a => a.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(b => b.Student);
        builder.HasOne(b => b.Country);
        builder.HasOne(b => b.City);
        builder.HasOne(b => b.District);

        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
    }
}