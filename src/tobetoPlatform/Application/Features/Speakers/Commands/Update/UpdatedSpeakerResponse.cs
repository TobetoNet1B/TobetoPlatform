using Core.Application.Responses;

namespace Application.Features.Speakers.Commands.Update;

public class UpdatedSpeakerResponse : IResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? About { get; set; }
}