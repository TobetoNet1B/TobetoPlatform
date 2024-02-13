using Core.Application.Responses;

namespace Application.Features.Instructors.Commands.Update;

public class UpdatedInstructorResponse : IResponse
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public string? ImgUrl { get; set; }
    public string? Description { get; set; }
}