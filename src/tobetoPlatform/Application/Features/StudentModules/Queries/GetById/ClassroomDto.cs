using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.StudentModules.Queries.GetById;
public class ClassroomDto
{
    public Guid ClassroomId { get; set; }
    public Guid ModuleSetId { get; set; }
    public string Name { get; set; }
    public DateTime? ClassroomStartDate { get; set; }
    public ModuleSetDto Module { get; set; }
}
