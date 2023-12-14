using Core.Application.Responses;

namespace Application.Features.Countries.Commands.Delete;

public class DeletedCountryResponse : IResponse
{
    public Guid Id { get; set; }
}