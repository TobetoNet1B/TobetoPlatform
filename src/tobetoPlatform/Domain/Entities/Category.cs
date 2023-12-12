using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Category: Entity<Guid>
{
    public string Name { get; set; }
    public virtual ICollection<CourseCategory> CourseCategories { get; set; } = null!;
    public bool? IsActive { get; set; }
    public int? ParentId { get; set; }//Üst Kategori
    public int? OrderNo { get; set; }//Kategori Sıra No
}
