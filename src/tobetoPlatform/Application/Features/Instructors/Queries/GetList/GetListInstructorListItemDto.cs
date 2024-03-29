using Core.Application.Dtos;

namespace Application.Features.Instructors.Queries.GetList;

public class GetListInstructorListItemDto : IDto
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public string? ImgUrl { get; set; }
    public string? Description { get; set; }
}