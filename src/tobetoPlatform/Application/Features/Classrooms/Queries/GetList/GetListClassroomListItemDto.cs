using Core.Application.Dtos;

namespace Application.Features.Classrooms.Queries.GetList;

public class GetListClassroomListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int ClassSize { get; set; }
}