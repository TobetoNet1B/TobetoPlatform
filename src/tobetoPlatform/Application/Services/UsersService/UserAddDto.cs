using Core.Security.Entities;

namespace Application.Services.UsersService;
public class UserAddDto : User
{
    public string Password { get; set; }
}
