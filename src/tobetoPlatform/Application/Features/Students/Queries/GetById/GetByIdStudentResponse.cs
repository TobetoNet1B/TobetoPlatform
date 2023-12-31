using Core.Application.Responses;

namespace Application.Features.Students.Queries.GetById;

public class GetByIdStudentResponse : IResponse
{
    public Guid Id { get; set; }
    public string? IdentityNumber { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? PhoneNumber { get; set; }
    public string? About { get; set; }
    public string? ImgUrl { get; set; }
}