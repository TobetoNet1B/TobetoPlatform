using Application.Features.Tags.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Tags.Commands.Update;

public class UpdateTagCommand : IRequest<UpdatedTagResponse>
{
    public Guid Id { get; set; }
    public string TagName { get; set; }

    public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand, UpdatedTagResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITagRepository _tagRepository;
        private readonly TagBusinessRules _tagBusinessRules;

        public UpdateTagCommandHandler(IMapper mapper, ITagRepository tagRepository,
                                         TagBusinessRules tagBusinessRules)
        {
            _mapper = mapper;
            _tagRepository = tagRepository;
            _tagBusinessRules = tagBusinessRules;
        }

        public async Task<UpdatedTagResponse> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            Tag? tag = await _tagRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _tagBusinessRules.TagShouldExistWhenSelected(tag);
            tag = _mapper.Map(request, tag);

            await _tagRepository.UpdateAsync(tag!);

            UpdatedTagResponse response = _mapper.Map<UpdatedTagResponse>(tag);
            return response;
        }
    }
}