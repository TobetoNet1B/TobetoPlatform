using Core.Application.Responses;

namespace Application.Features.CourseInstructors.Commands.Update;

public class UpdatedCourseInstructorResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid InstructorId { get; set; }
    public Guid CourseId { get; set; }
}