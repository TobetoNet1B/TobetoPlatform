using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.StudentSocialMedias.Queries.GetById;
public class SocialMediaDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? IconUrl { get; set; }
    public string? SocialMediaUrl { get; set; }
}
