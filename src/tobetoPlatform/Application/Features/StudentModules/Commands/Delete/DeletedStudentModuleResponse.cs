using Core.Application.Responses;

namespace Application.Features.StudentModules.Commands.Delete;

public class DeletedStudentModuleResponse : IResponse
{
    public Guid Id { get; set; }
}