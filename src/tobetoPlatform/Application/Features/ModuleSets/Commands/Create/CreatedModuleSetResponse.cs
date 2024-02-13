using Core.Application.Responses;

namespace Application.Features.ModuleSets.Commands.Create;

public class CreatedModuleSetResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? EducationType { get; set; }
    public string? CourseLevel { get; set; }
    public string? Topic { get; set; }
    public Guid? SoftwareLanguageId { get; set; }
    public Guid? InstructorId { get; set; }
    public string? ActivityStatus { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? EstimatedTime { get; set; }
    public string? ImgUrl { get; set; }
    public Guid? CompanyId { get; set; }
    public Guid? ModuleTypeId { get; set; }
}