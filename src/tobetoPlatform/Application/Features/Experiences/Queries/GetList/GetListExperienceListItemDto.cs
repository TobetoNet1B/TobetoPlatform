using Core.Application.Dtos;

namespace Application.Features.Experiences.Queries.GetList;

public class GetListExperienceListItemDto : IDto
{
    public Guid Id { get; set; }
    public string CompanyName { get; set; }
    public string Position { get; set; }
    public string Sector { get; set; }
    public string? Description { get; set; }
    public Guid CityId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool? IsContinueJob { get; set; }
    public Guid StudentId { get; set; }
}