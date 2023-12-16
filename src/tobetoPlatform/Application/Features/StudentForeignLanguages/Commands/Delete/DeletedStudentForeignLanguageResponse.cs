using Core.Application.Responses;

namespace Application.Features.StudentForeignLanguages.Commands.Delete;

public class DeletedStudentForeignLanguageResponse : IResponse
{
    public Guid Id { get; set; }
}