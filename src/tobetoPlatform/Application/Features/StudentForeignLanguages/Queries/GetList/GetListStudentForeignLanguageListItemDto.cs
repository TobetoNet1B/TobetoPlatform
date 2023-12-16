using Core.Application.Dtos;

namespace Application.Features.StudentForeignLanguages.Queries.GetList;

public class GetListStudentForeignLanguageListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid ForeignLanguageId { get; set; }
    public Guid ForeignLanguageLevelId { get; set; }
}