using Core.Application.Dtos;

namespace Application.Features.StudentClassrooms.Queries.GetList;

public class GetListStudentClassroomListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid ClassroomId { get; set; }
}