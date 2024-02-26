using Core.Application.Responses;
using Domain.Entities;

namespace Application.Features.StudentLessons.Commands.Update;

public class UpdatedStudentLessonResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid? StudentId { get; set; }
    public Guid? LessonId { get; set; }
    public bool? IsLiked { get; set; }
    public bool? IsWatched { get; set; }
}