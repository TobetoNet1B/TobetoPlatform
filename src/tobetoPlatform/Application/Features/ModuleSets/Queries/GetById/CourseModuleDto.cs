namespace Application.Features.ModuleSets.Queries.GetById;
public class CourseModuleDto
{
    public string Name { get; set; }
    public List<LessonDto> Lessons { get; set; }
}
