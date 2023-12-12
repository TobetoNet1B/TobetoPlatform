using Core.Application.Responses;

namespace Application.Features.CourseStudents.Queries.GetById;

public class GetByIdCourseStudentResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public Guid StudentId { get; set; }
}