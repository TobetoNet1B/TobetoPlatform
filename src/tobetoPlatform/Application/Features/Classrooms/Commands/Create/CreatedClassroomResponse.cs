using Core.Application.Responses;

namespace Application.Features.Classrooms.Commands.Create;

public class CreatedClassroomResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int ClassSize { get; set; }
}