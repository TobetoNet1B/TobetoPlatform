using Core.Persistence.Repositories;


namespace Domain.Entities;
public class Address : Entity<Guid>
{
    public Guid? CountryId { get; set; }
    public Guid? CityId { get; set; }
    public Guid? DistrictId { get; set; }
    public Guid? StudentId { get; set; }
    public string? AddressDetails { get; set; }
    public virtual City City { get; set; } = null!;
    public virtual Country Country { get; set; } = null!;
    public virtual District District { get; set; } = null!;
    public virtual Student Student { get; set; } = null!;

    public Address()
    {
        
    }
    public Address(Guid id, Guid? countryId, Guid? cityId, Guid? districtId, Guid? studentId, string? addressDetails) : base(id)
    {
        CountryId = countryId;
        CityId = cityId;
        DistrictId = districtId;
        StudentId = studentId;
        AddressDetails = addressDetails;
    }
}
