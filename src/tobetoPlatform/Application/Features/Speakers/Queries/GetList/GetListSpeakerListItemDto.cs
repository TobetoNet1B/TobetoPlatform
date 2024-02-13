using Core.Application.Dtos;

namespace Application.Features.Speakers.Queries.GetList;

public class GetListSpeakerListItemDto : IDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? About { get; set; }
}