using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Language : Entity<Guid>
    {
        public string Name { get; set; }
        public Guid ParticipantId { get; set; }
        public Participant Participant { get; set; }
        public Enums.LanguageLevel LanguageLevel { get; set; }
        
        //public class LanguageLevel
        //{
        //    string TemelSeviye = ""; 
        //    public string Name { get; set; }
        //}
    }
}
