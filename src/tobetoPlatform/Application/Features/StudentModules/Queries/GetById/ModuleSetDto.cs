namespace Application.Features.StudentModules.Queries.GetById;

public class ModuleSetDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ImgUrl { get; set; }
    public string CompanyName { get; set; }
    public DateTime StartDate { get; set; }
}