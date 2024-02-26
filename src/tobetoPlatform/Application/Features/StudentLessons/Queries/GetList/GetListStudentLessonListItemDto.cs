using Core.Application.Dtos;
using Domain.Entities;

namespace Application.Features.StudentLessons.Queries.GetList;

public class GetListStudentLessonListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid? StudentId { get; set; }
    public Guid? LessonId { get; set; }
    public bool? IsLiked { get; set; }
    public bool? IsWatched { get; set; }
}