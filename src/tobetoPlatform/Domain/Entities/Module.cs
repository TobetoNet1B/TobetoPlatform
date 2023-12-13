using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Module:Entity<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImgUrl { get; set; }
    public Guid CategoryId { get; set; }
    public Guid SoftwareLanguageId { get; set; }
    public Guid CompanyId { get; set; }
    public virtual Category Category { get; set; } = null!;
    public virtual Company Company{ get; set; } = null!;
    public virtual SoftwareLanguage SoftwareLanguage { get; set; }= null!;
    public virtual ICollection<CourseModule> CourseModules { get; set; } = null!;
    public virtual ICollection<StudentModule> StudentModules { get; set; } = null!;
    public Module()
    {
        
    }

    public Module(Guid id,string name, string description, string imgUrl, Guid categoryId, Guid softwareLanguageId, Guid companyId, Category category, Company company, SoftwareLanguage softwareLanguage, ICollection<CourseModule> courseModules, ICollection<StudentModule> studentModules) : base(id)
    {
        Name = name;
        Description = description;
        ImgUrl = imgUrl;
        CategoryId = categoryId;
        SoftwareLanguageId = softwareLanguageId;
        CompanyId = companyId;
        Category = category;
        Company = company;
        SoftwareLanguage = softwareLanguage;
        CourseModules = courseModules;
        StudentModules = studentModules;
    }
}
