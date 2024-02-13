using Application.Features.Speakers.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Speakers;

public class SpeakersManager : ISpeakersService
{
    private readonly ISpeakerRepository _speakerRepository;
    private readonly SpeakerBusinessRules _speakerBusinessRules;

    public SpeakersManager(ISpeakerRepository speakerRepository, SpeakerBusinessRules speakerBusinessRules)
    {
        _speakerRepository = speakerRepository;
        _speakerBusinessRules = speakerBusinessRules;
    }

    public async Task<Speaker?> GetAsync(
        Expression<Func<Speaker, bool>> predicate,
        Func<IQueryable<Speaker>, IIncludableQueryable<Speaker, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Speaker? speaker = await _speakerRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return speaker;
    }

    public async Task<IPaginate<Speaker>?> GetListAsync(
        Expression<Func<Speaker, bool>>? predicate = null,
        Func<IQueryable<Speaker>, IOrderedQueryable<Speaker>>? orderBy = null,
        Func<IQueryable<Speaker>, IIncludableQueryable<Speaker, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Speaker> speakerList = await _speakerRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return speakerList;
    }

    public async Task<Speaker> AddAsync(Speaker speaker)
    {
        Speaker addedSpeaker = await _speakerRepository.AddAsync(speaker);

        return addedSpeaker;
    }

    public async Task<Speaker> UpdateAsync(Speaker speaker)
    {
        Speaker updatedSpeaker = await _speakerRepository.UpdateAsync(speaker);

        return updatedSpeaker;
    }

    public async Task<Speaker> DeleteAsync(Speaker speaker, bool permanent = false)
    {
        Speaker deletedSpeaker = await _speakerRepository.DeleteAsync(speaker);

        return deletedSpeaker;
    }
}
