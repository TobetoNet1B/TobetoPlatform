using Core.Application.Responses;

namespace Application.Features.StudentSocialMedias.Queries.GetById;

public class GetByIdStudentSocialMediaResponse : IResponse
{

    public Guid StudentId { get; set; }
    //public Guid SocialMediaId { get; set; }

    public List<SocialMediaDto> SocialMedia { get; set; }=new List<SocialMediaDto>();
}