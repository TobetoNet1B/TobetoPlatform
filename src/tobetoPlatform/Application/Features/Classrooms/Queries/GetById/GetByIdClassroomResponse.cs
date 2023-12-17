using Core.Application.Responses;

namespace Application.Features.Classrooms.Queries.GetById;

public class GetByIdClassroomResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int ClassSize { get; set; }
}