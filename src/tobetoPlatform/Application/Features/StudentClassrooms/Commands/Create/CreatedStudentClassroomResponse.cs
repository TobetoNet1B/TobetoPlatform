using Core.Application.Responses;

namespace Application.Features.StudentClassrooms.Commands.Create;

public class CreatedStudentClassroomResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid ClassroomId { get; set; }
}