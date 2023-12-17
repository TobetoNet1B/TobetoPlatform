using Core.Application.Responses;

namespace Application.Features.StudentClassrooms.Queries.GetById;

public class GetByIdStudentClassroomResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid ClassroomId { get; set; }
}