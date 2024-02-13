using Core.Application.Responses;

namespace Application.Features.ClassroomModules.Queries.GetById;

public class GetByIdClassroomModuleResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid ClassroomId { get; set; }
    public Guid ModuleSetId { get; set; }
    public DateTime? ClassroomStartDate { get; set; }
    public DateTime? ClassroomEndDate { get; set; }
}