using Core.Application.Responses;

namespace Application.Features.ForeignLanguageLevels.Commands.Create;

public class CreatedForeignLanguageLevelResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}