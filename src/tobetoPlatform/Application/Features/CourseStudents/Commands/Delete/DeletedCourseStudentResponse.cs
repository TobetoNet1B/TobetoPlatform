using Core.Application.Responses;

namespace Application.Features.CourseStudents.Commands.Delete;

public class DeletedCourseStudentResponse : IResponse
{
    public Guid Id { get; set; }
}