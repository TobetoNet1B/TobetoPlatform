using Application.Features.Announcements.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Announcements.Commands.Update;

public class UpdateAnnouncementCommand : IRequest<UpdatedAnnouncementResponse>
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public class UpdateAnnouncementCommandHandler : IRequestHandler<UpdateAnnouncementCommand, UpdatedAnnouncementResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAnnouncementRepository _announcementRepository;
        private readonly AnnouncementBusinessRules _announcementBusinessRules;

        public UpdateAnnouncementCommandHandler(IMapper mapper, IAnnouncementRepository announcementRepository,
                                         AnnouncementBusinessRules announcementBusinessRules)
        {
            _mapper = mapper;
            _announcementRepository = announcementRepository;
            _announcementBusinessRules = announcementBusinessRules;
        }

        public async Task<UpdatedAnnouncementResponse> Handle(UpdateAnnouncementCommand request, CancellationToken cancellationToken)
        {
            Announcement? announcement = await _announcementRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _announcementBusinessRules.AnnouncementShouldExistWhenSelected(announcement);
            announcement = _mapper.Map(request, announcement);

            await _announcementRepository.UpdateAsync(announcement!);

            UpdatedAnnouncementResponse response = _mapper.Map<UpdatedAnnouncementResponse>(announcement);
            return response;
        }
    }
}