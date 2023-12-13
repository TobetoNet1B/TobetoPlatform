using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Category: Entity<Guid>
{
    public string Name { get; set; }
    public bool? IsActive { get; set; }
    public int? ParentId { get; set; }//Üst Kategori
    public int? OrderNo { get; set; }//Kategori Sıra No
    public virtual ICollection<CourseCategory> CourseCategories { get; set; } = null!;
    public virtual ICollection<Module> Modules { get; set; } = null!;
    public Category()
    {
        
    }
    public Category(Guid id,string name, bool? isActive, int? parentId, int? orderNo, ICollection<CourseCategory> courseCategories, ICollection<Module> modules) : base(id)
    {
        Name = name;
        IsActive = isActive;
        ParentId = parentId;
        OrderNo = orderNo;
        CourseCategories = courseCategories;
        Modules = modules;
    }
}
