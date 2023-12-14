using Core.Application.Responses;

namespace Application.Features.Experiences.Commands.Update;

public class UpdatedExperienceResponse : IResponse
{
    public Guid Id { get; set; }
    public string CompanyName { get; set; }
    public string Position { get; set; }
    public string Sector { get; set; }
    public Guid CityId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsContinueJob { get; set; }
    public Guid StudentId { get; set; }
}