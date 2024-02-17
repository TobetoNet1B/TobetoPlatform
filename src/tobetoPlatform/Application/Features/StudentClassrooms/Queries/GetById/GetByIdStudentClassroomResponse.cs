using Core.Application.Responses;
using Org.BouncyCastle.Utilities.IO.Pem;

namespace Application.Features.StudentClassrooms.Queries.GetById;

public class GetByIdStudentClassroomResponse : IResponse
{
    public ClassroomDto Classroom { get; set; }
    public StudentDto Student { get; set; }
    public List<ModuleSetDto> ModuleSets { get; set; } = new List<ModuleSetDto>();
}