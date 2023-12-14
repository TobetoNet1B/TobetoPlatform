using Core.Application.Responses;

namespace Application.Features.Announcements.Commands.Update;

public class UpdatedAnnouncementResponse : IResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}