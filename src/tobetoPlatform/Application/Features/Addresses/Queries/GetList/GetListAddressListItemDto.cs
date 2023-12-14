using Core.Application.Dtos;

namespace Application.Features.Addresses.Queries.GetList;

public class GetListAddressListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid? CountryId { get; set; }
    public Guid? CityId { get; set; }
    public Guid? DistrictId { get; set; }
    public Guid? StudentId { get; set; }
    public string? AddressDetails { get; set; }
}