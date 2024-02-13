using Core.Persistence.Repositories;


namespace Domain.Entities;
public class Speaker : Entity<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? About { get; set; }
    public virtual ICollection<Lesson> Lessons { get; set; } = null!;
    public Speaker()
    {
    }

    public Speaker(string firstName, string lastName, string? about)
    {
        FirstName = firstName;
        LastName = lastName;
        About = about;
    }
}
