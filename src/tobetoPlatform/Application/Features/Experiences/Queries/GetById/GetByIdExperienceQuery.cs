using Application.Features.Abilities.Queries.GetById;
using Application.Features.Experiences.Rules;
using Application.Features.StudentSocialMedias.Queries.GetById;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Experiences.Queries.GetById;

public class GetByIdExperienceQuery : IRequest<List<GetByIdExperienceResponse>>
{
    public Guid Id { get; set; }

    public class GetByIdExperienceQueryHandler : IRequestHandler<GetByIdExperienceQuery, List<GetByIdExperienceResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IExperienceRepository _experienceRepository;
        private readonly ExperienceBusinessRules _experienceBusinessRules;

        public GetByIdExperienceQueryHandler(IMapper mapper, IExperienceRepository experienceRepository, ExperienceBusinessRules experienceBusinessRules)
        {
            _mapper = mapper;
            _experienceRepository = experienceRepository;
            _experienceBusinessRules = experienceBusinessRules;
        }

        public async Task<List<GetByIdExperienceResponse>> Handle(GetByIdExperienceQuery request, CancellationToken cancellationToken)
        {
            //Experience? experience = await _experienceRepository.GetAsync(predicate: e => e.Id == request.Id, cancellationToken: cancellationToken);
            //await _experienceBusinessRules.ExperienceShouldExistWhenSelected(experience);

            //GetByIdExperienceResponse response = _mapper.Map<GetByIdExperienceResponse>(experience);
            //return response;
            var experience = await _experienceRepository.GetListAsync(predicate: ssm => ssm.StudentId == request.Id, include: m => m.Include(s => s.City)
                    , cancellationToken: cancellationToken);
  
            CityDto cityDto = experience.Items.Select(ssm => _mapper.Map<CityDto>(ssm.City)).FirstOrDefault();

            List<GetByIdExperienceResponse> response = _mapper.Map<List<GetByIdExperienceResponse>>(experience.Items);
            return response;
        }
    }
}