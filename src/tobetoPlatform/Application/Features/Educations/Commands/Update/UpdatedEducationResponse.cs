using Core.Application.Responses;

namespace Application.Features.Educations.Commands.Update;

public class UpdatedEducationResponse : IResponse
{
    public Guid Id { get; set; }
    public string EducationState { get; set; }
    public string University { get; set; }
    public string Department { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsContinueUniversity { get; set; }
    public Guid StudentId { get; set; }
}