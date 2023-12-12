using Core.Application.Responses;

namespace Application.Features.CourseInstructors.Commands.Create;

public class CreatedCourseInstructorResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid InstructorId { get; set; }
    public Guid CourseId { get; set; }
}