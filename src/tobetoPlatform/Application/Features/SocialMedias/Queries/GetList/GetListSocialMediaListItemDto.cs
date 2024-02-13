using Core.Application.Dtos;

namespace Application.Features.SocialMedias.Queries.GetList;

public class GetListSocialMediaListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? IconUrl { get; set; }
}