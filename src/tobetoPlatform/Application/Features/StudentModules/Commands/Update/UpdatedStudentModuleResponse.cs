using Core.Application.Responses;

namespace Application.Features.StudentModules.Commands.Update;

public class UpdatedStudentModuleResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid ModuleSetId { get; set; }
    public int? TimeSpent { get; set; }
    public bool? IsCompleted { get; set; }
    public bool? IsLiked { get; set; }
    public bool? IsFav { get; set; }
}