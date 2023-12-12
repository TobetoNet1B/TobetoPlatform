using Application.Features.Tags.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Tags.Commands.Create;

public class CreateTagCommand : IRequest<CreatedTagResponse>
{
    public string TagName { get; set; }

    public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, CreatedTagResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITagRepository _tagRepository;
        private readonly TagBusinessRules _tagBusinessRules;

        public CreateTagCommandHandler(IMapper mapper, ITagRepository tagRepository,
                                         TagBusinessRules tagBusinessRules)
        {
            _mapper = mapper;
            _tagRepository = tagRepository;
            _tagBusinessRules = tagBusinessRules;
        }

        public async Task<CreatedTagResponse> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            await _tagBusinessRules.TagNameCanBotBeDuplicationWhenInserted(request.TagName);
            Tag tag = _mapper.Map<Tag>(request);

            await _tagRepository.AddAsync(tag);

            CreatedTagResponse response = _mapper.Map<CreatedTagResponse>(tag);
            return response;
        }
    }
}