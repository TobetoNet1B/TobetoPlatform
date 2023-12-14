using Core.Application.Dtos;

namespace Application.Features.Companies.Queries.GetList;

public class GetListCompanyListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}