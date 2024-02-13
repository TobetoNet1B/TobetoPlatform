using Core.Application.Responses;

namespace Application.Features.ClassroomModules.Commands.Delete;

public class DeletedClassroomModuleResponse : IResponse
{
    public Guid Id { get; set; }
}