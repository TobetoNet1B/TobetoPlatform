using Core.Application.Responses;

namespace Application.Features.StudentModules.Queries.GetById;

public class GetByIdStudentModuleResponse : IResponse
{
    public Guid Id { get; set; }
    public StudentDto Student { get; set; }
    public List<ModuleSetDto> ModuleSets { get; set; } = new List<ModuleSetDto>();
    public int? TimeSpent { get; set; }
}