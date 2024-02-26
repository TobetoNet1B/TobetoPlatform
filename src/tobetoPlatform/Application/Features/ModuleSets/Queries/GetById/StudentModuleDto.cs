namespace Application.Features.ModuleSets.Queries.GetById;
public class StudentModuleDto
{
    public Guid StudentId { get; set; }
    public int? TimeSpent { get; set; }
    public bool? IsLiked { get; set; }
    public bool? IsFav { get; set; }
}
