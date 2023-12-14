using Core.Application.Responses;

namespace Application.Features.Experiences.Commands.Delete;

public class DeletedExperienceResponse : IResponse
{
    public Guid Id { get; set; }
}