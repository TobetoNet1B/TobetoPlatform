using Core.Application.Responses;

namespace Application.Features.StudentClassrooms.Commands.Delete;

public class DeletedStudentClassroomResponse : IResponse
{
    public Guid Id { get; set; }
}