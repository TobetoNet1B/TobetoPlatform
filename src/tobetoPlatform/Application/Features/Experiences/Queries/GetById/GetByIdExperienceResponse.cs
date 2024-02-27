using Core.Application.Responses;

namespace Application.Features.Experiences.Queries.GetById;

public class GetByIdExperienceResponse : IResponse
{
    public string CompanyName { get; set; }
    public string Position { get; set; }
    public string Sector { get; set; }
    public string Description { get; set; }
    //public Guid CityId { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsContinueJob { get; set; }
    public Guid StudentId { get; set; }
    public CityDto City { get; set; } = new CityDto();
}