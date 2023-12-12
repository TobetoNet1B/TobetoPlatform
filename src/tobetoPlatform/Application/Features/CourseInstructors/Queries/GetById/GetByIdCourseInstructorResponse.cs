using Core.Application.Responses;

namespace Application.Features.CourseInstructors.Queries.GetById;

public class GetByIdCourseInstructorResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid InstructorId { get; set; }
    public Guid CourseId { get; set; }
}