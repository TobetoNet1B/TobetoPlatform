using Core.Application.Responses;

namespace Application.Features.ForeignLanguages.Commands.Create;

public class CreatedForeignLanguageResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid? StudentId { get; set; }
    public Guid ForeignLanguageLevelId { get; set; }
}