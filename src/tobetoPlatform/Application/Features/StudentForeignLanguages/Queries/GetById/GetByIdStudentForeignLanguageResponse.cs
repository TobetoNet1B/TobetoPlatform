using Core.Application.Responses;

namespace Application.Features.StudentForeignLanguages.Queries.GetById;

public class GetByIdStudentForeignLanguageResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid ForeignLanguageId { get; set; }
    public Guid ForeignLanguageLevelId { get; set; }
}