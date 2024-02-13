using Core.Application.Responses;

namespace Application.Features.Instructors.Queries.GetById;

public class GetByIdInstructorResponse : IResponse
{
    public Guid Id { get; set; }
    public int UserId { get; set; }
    public string? ImgUrl { get; set; }
    public string? Description { get; set; }
}