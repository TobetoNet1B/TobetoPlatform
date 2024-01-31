using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Students.Queries.GetById;
public class StudentClassroomsDto
{
    public Guid StudentId { get; set; }
    public Guid ClassroomId { get; set; }


    public string StudentName { get; set; }
    public string ClassName { get; set; }
    public int ClassSize { get; set; }

}