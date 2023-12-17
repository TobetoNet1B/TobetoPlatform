using Core.Application.Responses;

namespace Application.Features.Classrooms.Commands.Update;

public class UpdatedClassroomResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int ClassSize { get; set; }
}