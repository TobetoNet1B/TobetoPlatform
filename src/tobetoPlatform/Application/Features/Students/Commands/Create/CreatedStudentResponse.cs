using Core.Application.Responses;

namespace Application.Features.Students.Commands.Create;

public class CreatedStudentResponse : IResponse
{
    public Guid Id { get; set; }
    public string? IdentityNumber { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? PhoneNumber { get; set; }
    public string? About { get; set; }
    public string? ImgUrl { get; set; }
    public int UserId { get; set; }
}