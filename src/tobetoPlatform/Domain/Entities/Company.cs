﻿using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Company:Entity<Guid>
{
    public string Name { get; set; }
    public virtual ICollection<Module> Modules { get; set; } = null!;
    public Company()
    {
        
    }
    public Company(Guid id,string name, ICollection<Module> modules) : base(id)
    {
        Name = name;
        Modules = modules;
    }
}
