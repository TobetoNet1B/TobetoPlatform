using Core.Application.Responses;

namespace Application.Features.Speakers.Commands.Delete;

public class DeletedSpeakerResponse : IResponse
{
    public Guid Id { get; set; }
}