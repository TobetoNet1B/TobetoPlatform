using Core.Application.Responses;

namespace Application.Features.Speakers.Queries.GetById;

public class GetByIdSpeakerResponse : IResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? About { get; set; }
}