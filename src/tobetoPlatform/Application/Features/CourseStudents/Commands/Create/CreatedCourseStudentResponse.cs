using Core.Application.Responses;

namespace Application.Features.CourseStudents.Commands.Create;

public class CreatedCourseStudentResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public Guid StudentId { get; set; }
}