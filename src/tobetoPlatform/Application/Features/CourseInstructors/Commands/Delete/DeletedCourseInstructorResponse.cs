using Core.Application.Responses;

namespace Application.Features.CourseInstructors.Commands.Delete;

public class DeletedCourseInstructorResponse : IResponse
{
    public Guid Id { get; set; }
}