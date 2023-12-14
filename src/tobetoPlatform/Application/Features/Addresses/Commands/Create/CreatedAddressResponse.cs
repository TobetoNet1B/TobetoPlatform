using Core.Application.Responses;

namespace Application.Features.Addresses.Commands.Create;

public class CreatedAddressResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid? CountryId { get; set; }
    public Guid? CityId { get; set; }
    public Guid? DistrictId { get; set; }
    public Guid? StudentId { get; set; }
    public string? AddressDetails { get; set; }
}