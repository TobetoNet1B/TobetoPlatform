using Core.Application.Responses;

namespace Application.Features.StudentModules.Queries.GetById;

public class GetByIdStudentModuleResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid ModuleSetId { get; set; }
    public int? TimeSpent { get; set; }
}