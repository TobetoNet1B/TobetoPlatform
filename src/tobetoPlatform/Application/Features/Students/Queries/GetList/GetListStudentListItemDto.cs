using Core.Application.Dtos;
using Core.Security.Entities;

namespace Application.Features.Students.Queries.GetList;

public class GetListStudentListItemDto : IDto
{
    public Guid Id { get; set; }
    public string? IdentityNumber { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? PhoneNumber { get; set; }
    public string? About { get; set; }
    public string? ImgUrl { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}