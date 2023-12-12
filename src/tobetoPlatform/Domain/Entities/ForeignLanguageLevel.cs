using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class ForeignLanguageLevel:Entity<Guid>
{
    public string Name { get; set; }
    public ForeignLanguage ForeignLanguage { get; set; }
    public Guid ForeignLanguageId { get; set; }
    //public List<ForeignLanguage> ForeignLanguages { get; set;}
}
