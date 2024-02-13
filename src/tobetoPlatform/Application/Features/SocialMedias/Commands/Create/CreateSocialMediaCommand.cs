using Application.Features.SocialMedias.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SocialMedias.Commands.Create;

public class CreateSocialMediaCommand : IRequest<CreatedSocialMediaResponse>
{
    public string Name { get; set; }
    public string? IconUrl { get; set; }

    public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand, CreatedSocialMediaResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISocialMediaRepository _socialMediaRepository;
        private readonly SocialMediaBusinessRules _socialMediaBusinessRules;

        public CreateSocialMediaCommandHandler(IMapper mapper, ISocialMediaRepository socialMediaRepository,
                                         SocialMediaBusinessRules socialMediaBusinessRules)
        {
            _mapper = mapper;
            _socialMediaRepository = socialMediaRepository;
            _socialMediaBusinessRules = socialMediaBusinessRules;
        }

        public async Task<CreatedSocialMediaResponse> Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            SocialMedia socialMedia = _mapper.Map<SocialMedia>(request);

            await _socialMediaRepository.AddAsync(socialMedia);

            CreatedSocialMediaResponse response = _mapper.Map<CreatedSocialMediaResponse>(socialMedia);
            return response;
        }
    }
}