using Core.Application.Dtos;

namespace Application.Features.CourseStudents.Queries.GetList;

public class GetListCourseStudentListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public Guid StudentId { get; set; }
}