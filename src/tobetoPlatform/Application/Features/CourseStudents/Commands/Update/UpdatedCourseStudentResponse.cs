using Core.Application.Responses;

namespace Application.Features.CourseStudents.Commands.Update;

public class UpdatedCourseStudentResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public Guid StudentId { get; set; }
}