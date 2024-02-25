using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.StudentLessons.Queries.GetById;

public class GetByIdStudentLessonResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid? StudentId { get; set; }
    public Guid? LessonId { get; set; }
    public bool? IsLiked { get; set; }
    public bool? IsWatched { get; set; }
}