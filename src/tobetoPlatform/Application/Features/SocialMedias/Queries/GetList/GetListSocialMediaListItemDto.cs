using Core.Application.Dtos;

namespace Application.Features.SocialMedias.Queries.GetList;

public class GetListSocialMediaListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Icon { get; set; }
    public string SocialMediaUrl { get; set; }
    public Guid StudentId { get; set; }
}