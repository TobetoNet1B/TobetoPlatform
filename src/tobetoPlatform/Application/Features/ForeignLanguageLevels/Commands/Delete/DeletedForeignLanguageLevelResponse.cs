using Core.Application.Responses;

namespace Application.Features.ForeignLanguageLevels.Commands.Delete;

public class DeletedForeignLanguageLevelResponse : IResponse
{
    public Guid Id { get; set; }
}