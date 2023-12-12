using Core.Application.Responses;

namespace Application.Features.ForeignLanguageLevels.Commands.Update;

public class UpdatedForeignLanguageLevelResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid ForeignLanguageId { get; set; }
}