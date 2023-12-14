using Core.Application.Responses;

namespace Application.Features.StudentModules.Commands.Update;

public class UpdatedStudentModuleResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid ModuleId { get; set; }
    public int? TimeSpent { get; set; }
}