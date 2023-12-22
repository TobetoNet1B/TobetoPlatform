using Core.Application.Dtos;
using Core.Security.Entities;

namespace Application.Features.Instructors.Queries.GetList;

public class GetListInstructorListItemDto : IDto
{
    public Guid Id { get; set; }
    public string? ImgUrl { get; set; }
    public string? Description { get; set; }
    public User User { get; set; }
}