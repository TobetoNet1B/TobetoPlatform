﻿using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Ability: Entity<Guid>
{
    public string Name { get; set; }
    public Guid ParticipantId { get; set; }
    public Participant Participant { get; set; }
}
