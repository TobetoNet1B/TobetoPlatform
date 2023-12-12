using Core.Application.Dtos;

namespace Application.Features.CourseInstructors.Queries.GetList;

public class GetListCourseInstructorListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid InstructorId { get; set; }
    public Guid CourseId { get; set; }
}