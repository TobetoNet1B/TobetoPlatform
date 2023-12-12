using Core.Application.Responses;

namespace Application.Features.Educations.Commands.Delete;

public class DeletedEducationResponse : IResponse
{
    public Guid Id { get; set; }
}