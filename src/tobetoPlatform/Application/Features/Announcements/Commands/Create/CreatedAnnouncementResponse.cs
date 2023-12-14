using Core.Application.Responses;

namespace Application.Features.Announcements.Commands.Create;

public class CreatedAnnouncementResponse : IResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}