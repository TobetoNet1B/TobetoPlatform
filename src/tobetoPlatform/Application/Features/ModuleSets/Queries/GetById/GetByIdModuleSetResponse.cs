using Application.Features.Students.Queries.GetById;
using Core.Application.Responses;

namespace Application.Features.ModuleSets.Queries.GetById;

public class GetByIdModuleSetResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? EstimatedTime { get; set; }
    public string? ImgUrl { get; set; }
    public Guid? CompanyId { get; set; }
    public CompanyDto? Company { get; set; } = new CompanyDto();
    public List<CourseModuleDto>? CourseModules { get; set; } = new List<CourseModuleDto>();
    public List<StudentModuleDto>? StudentModules { get; set; } = new List<StudentModuleDto>();
    public List<ModuleSetCategoryDto>? ModuleSetCategorys { get; set; } = new List<ModuleSetCategoryDto>();
}