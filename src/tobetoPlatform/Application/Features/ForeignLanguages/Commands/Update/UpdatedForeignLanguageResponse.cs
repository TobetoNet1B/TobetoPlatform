using Core.Application.Responses;

namespace Application.Features.ForeignLanguages.Commands.Update;

public class UpdatedForeignLanguageResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}