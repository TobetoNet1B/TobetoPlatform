using Core.Application.Responses;

namespace Application.Features.Appeals.Commands.Update;

public class UpdatedAppealResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid StudentId { get; set; }
}