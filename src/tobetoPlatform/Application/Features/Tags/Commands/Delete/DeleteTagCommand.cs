using Application.Features.Tags.Constants;
using Application.Features.Tags.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Tags.Commands.Delete;

public class DeleteTagCommand : IRequest<DeletedTagResponse>
{
    public Guid Id { get; set; }

    public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, DeletedTagResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITagRepository _tagRepository;
        private readonly TagBusinessRules _tagBusinessRules;

        public DeleteTagCommandHandler(IMapper mapper, ITagRepository tagRepository,
                                         TagBusinessRules tagBusinessRules)
        {
            _mapper = mapper;
            _tagRepository = tagRepository;
            _tagBusinessRules = tagBusinessRules;
        }

        public async Task<DeletedTagResponse> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            Tag? tag = await _tagRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _tagBusinessRules.TagShouldExistWhenSelected(tag);

            await _tagRepository.DeleteAsync(tag!);

            DeletedTagResponse response = _mapper.Map<DeletedTagResponse>(tag);
            return response;
        }
    }
}