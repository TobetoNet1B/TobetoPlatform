using Application.Features.SocialMedias.Constants;
using Application.Features.SocialMedias.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SocialMedias.Commands.Delete;

public class DeleteSocialMediaCommand : IRequest<DeletedSocialMediaResponse>
{
    public Guid Id { get; set; }

    public class DeleteSocialMediaCommandHandler : IRequestHandler<DeleteSocialMediaCommand, DeletedSocialMediaResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISocialMediaRepository _socialMediaRepository;
        private readonly SocialMediaBusinessRules _socialMediaBusinessRules;

        public DeleteSocialMediaCommandHandler(IMapper mapper, ISocialMediaRepository socialMediaRepository,
                                         SocialMediaBusinessRules socialMediaBusinessRules)
        {
            _mapper = mapper;
            _socialMediaRepository = socialMediaRepository;
            _socialMediaBusinessRules = socialMediaBusinessRules;
        }

        public async Task<DeletedSocialMediaResponse> Handle(DeleteSocialMediaCommand request, CancellationToken cancellationToken)
        {
            SocialMedia? socialMedia = await _socialMediaRepository.GetAsync(predicate: sm => sm.Id == request.Id, cancellationToken: cancellationToken);
            await _socialMediaBusinessRules.SocialMediaShouldExistWhenSelected(socialMedia);

            await _socialMediaRepository.DeleteAsync(socialMedia!);

            DeletedSocialMediaResponse response = _mapper.Map<DeletedSocialMediaResponse>(socialMedia);
            return response;
        }
    }
}