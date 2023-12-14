using Core.Application.Responses;

namespace Application.Features.ForeignLanguages.Commands.Delete;

public class DeletedForeignLanguageResponse : IResponse
{
    public Guid Id { get; set; }
}