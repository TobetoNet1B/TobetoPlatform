using Core.Application.Responses;

namespace Application.Features.SoftwareLanguages.Commands.Delete;

public class DeletedSoftwareLanguageResponse : IResponse
{
    public Guid Id { get; set; }
}