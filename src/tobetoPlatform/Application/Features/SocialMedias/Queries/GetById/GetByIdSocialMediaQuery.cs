using Application.Features.SocialMedias.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SocialMedias.Queries.GetById;

public class GetByIdSocialMediaQuery : IRequest<GetByIdSocialMediaResponse>
{
    public Guid Id { get; set; }

    public class GetByIdSocialMediaQueryHandler : IRequestHandler<GetByIdSocialMediaQuery, GetByIdSocialMediaResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISocialMediaRepository _socialMediaRepository;
        private readonly SocialMediaBusinessRules _socialMediaBusinessRules;

        public GetByIdSocialMediaQueryHandler(IMapper mapper, ISocialMediaRepository socialMediaRepository, SocialMediaBusinessRules socialMediaBusinessRules)
        {
            _mapper = mapper;
            _socialMediaRepository = socialMediaRepository;
            _socialMediaBusinessRules = socialMediaBusinessRules;
        }

        public async Task<GetByIdSocialMediaResponse> Handle(GetByIdSocialMediaQuery request, CancellationToken cancellationToken)
        {
            SocialMedia? socialMedia = await _socialMediaRepository.GetAsync(predicate: sm => sm.Id == request.Id, cancellationToken: cancellationToken);
            await _socialMediaBusinessRules.SocialMediaShouldExistWhenSelected(socialMedia);

            GetByIdSocialMediaResponse response = _mapper.Map<GetByIdSocialMediaResponse>(socialMedia);
            return response;
        }
    }
}