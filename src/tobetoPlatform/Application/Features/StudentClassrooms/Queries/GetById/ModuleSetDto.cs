using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.StudentClassrooms.Queries.GetById;
public class ModuleSetDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ImgUrl { get; set; }
    public string CompanyName { get; set; }
    public DateTime? ClassroomStartDate { get; set; }
}
