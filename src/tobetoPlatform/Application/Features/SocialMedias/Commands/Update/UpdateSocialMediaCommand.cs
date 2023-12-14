using Application.Features.SocialMedias.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SocialMedias.Commands.Update;

public class UpdateSocialMediaCommand : IRequest<UpdatedSocialMediaResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Icon { get; set; }
    public string SocialMediaUrl { get; set; }
    public Guid StudentId { get; set; }

    public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand, UpdatedSocialMediaResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISocialMediaRepository _socialMediaRepository;
        private readonly SocialMediaBusinessRules _socialMediaBusinessRules;

        public UpdateSocialMediaCommandHandler(IMapper mapper, ISocialMediaRepository socialMediaRepository,
                                         SocialMediaBusinessRules socialMediaBusinessRules)
        {
            _mapper = mapper;
            _socialMediaRepository = socialMediaRepository;
            _socialMediaBusinessRules = socialMediaBusinessRules;
        }

        public async Task<UpdatedSocialMediaResponse> Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            SocialMedia? socialMedia = await _socialMediaRepository.GetAsync(predicate: sm => sm.Id == request.Id, cancellationToken: cancellationToken);
            await _socialMediaBusinessRules.SocialMediaShouldExistWhenSelected(socialMedia);
            socialMedia = _mapper.Map(request, socialMedia);

            await _socialMediaRepository.UpdateAsync(socialMedia!);

            UpdatedSocialMediaResponse response = _mapper.Map<UpdatedSocialMediaResponse>(socialMedia);
            return response;
        }
    }
}