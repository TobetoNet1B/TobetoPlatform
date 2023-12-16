using Core.Application.Responses;

namespace Application.Features.StudentForeignLanguages.Commands.Update;

public class UpdatedStudentForeignLanguageResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid ForeignLanguageId { get; set; }
    public Guid ForeignLanguageLevelId { get; set; }
}