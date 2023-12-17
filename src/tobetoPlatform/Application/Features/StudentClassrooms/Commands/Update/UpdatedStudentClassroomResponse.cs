using Core.Application.Responses;

namespace Application.Features.StudentClassrooms.Commands.Update;

public class UpdatedStudentClassroomResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid ClassroomId { get; set; }
}