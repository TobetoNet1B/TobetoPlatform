using Core.Application.Responses;

namespace Application.Features.StudentModules.Commands.Create;

public class CreatedStudentModuleResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid ModuleId { get; set; }
    public int? TimeSpent { get; set; }
}