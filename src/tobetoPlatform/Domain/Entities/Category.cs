using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Category: Entity<Guid>
{
    public string Name { get; set; }
    public List<Course> Courses { get; set; }
    //[Display(Name = "Durum")]
    public bool IsActive { get; set; }

    //[Display(Name = "Üst Kategori")]
    public int ParentId { get; set; }

    //[Display(Name = "Kategori Sıra No")]
    public int OrderNo { get; set; }
}
