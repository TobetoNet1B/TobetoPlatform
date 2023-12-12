using Core.Application.Responses;

namespace Application.Features.SocialMedias.Commands.Create;

public class CreatedSocialMediaResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Icon { get; set; }
    public string SocialMediaUrl { get; set; }
    public Guid StudentId { get; set; }
}