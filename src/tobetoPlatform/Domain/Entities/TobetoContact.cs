using Core.Persistence.Repositories;

namespace Domain.Entities;
public class TobetoContact : Entity<Guid>
{
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? Message { get; set; }
    public bool? IsReaded { get; set; }

    public TobetoContact()
    {
    }

    public TobetoContact(Guid id, string? fullName, string? email, string? message, bool? ısReaded) : base(id)
    {
        FullName = fullName;
        Email = email;
        Message = message;
        IsReaded = ısReaded;
    }
}
