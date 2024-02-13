using Application.Features.StudentSocialMedias.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentSocialMedias.Commands.Update;

public class UpdateStudentSocialMediaCommand : IRequest<UpdatedStudentSocialMediaResponse>
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid SocialMediaId { get; set; }
    public string? SocialMediaUrl { get; set; }

    public class UpdateStudentSocialMediaCommandHandler : IRequestHandler<UpdateStudentSocialMediaCommand, UpdatedStudentSocialMediaResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentSocialMediaRepository _studentSocialMediaRepository;
        private readonly StudentSocialMediaBusinessRules _studentSocialMediaBusinessRules;

        public UpdateStudentSocialMediaCommandHandler(IMapper mapper, IStudentSocialMediaRepository studentSocialMediaRepository,
                                         StudentSocialMediaBusinessRules studentSocialMediaBusinessRules)
        {
            _mapper = mapper;
            _studentSocialMediaRepository = studentSocialMediaRepository;
            _studentSocialMediaBusinessRules = studentSocialMediaBusinessRules;
        }

        public async Task<UpdatedStudentSocialMediaResponse> Handle(UpdateStudentSocialMediaCommand request, CancellationToken cancellationToken)
        {
            StudentSocialMedia? studentSocialMedia = await _studentSocialMediaRepository.GetAsync(predicate: ssm => ssm.Id == request.Id, cancellationToken: cancellationToken);
            await _studentSocialMediaBusinessRules.StudentSocialMediaShouldExistWhenSelected(studentSocialMedia);
            studentSocialMedia = _mapper.Map(request, studentSocialMedia);

            await _studentSocialMediaRepository.UpdateAsync(studentSocialMedia!);

            UpdatedStudentSocialMediaResponse response = _mapper.Map<UpdatedStudentSocialMediaResponse>(studentSocialMedia);
            return response;
        }
    }
}