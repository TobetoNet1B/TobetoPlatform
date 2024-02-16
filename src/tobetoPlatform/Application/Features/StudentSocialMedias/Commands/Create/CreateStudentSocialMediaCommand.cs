using Application.Features.StudentSocialMedias.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentSocialMedias.Commands.Create;

public class CreateStudentSocialMediaCommand : IRequest<CreatedStudentSocialMediaResponse>
{
    public Guid StudentId { get; set; }
    public Guid SocialMediaId { get; set; }
    public string? SocialMediaUrl { get; set; }

    public class CreateStudentSocialMediaCommandHandler : IRequestHandler<CreateStudentSocialMediaCommand, CreatedStudentSocialMediaResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentSocialMediaRepository _studentSocialMediaRepository;
        private readonly StudentSocialMediaBusinessRules _studentSocialMediaBusinessRules;

        public CreateStudentSocialMediaCommandHandler(IMapper mapper, IStudentSocialMediaRepository studentSocialMediaRepository,
                                         StudentSocialMediaBusinessRules studentSocialMediaBusinessRules)
        {
            _mapper = mapper;
            _studentSocialMediaRepository = studentSocialMediaRepository;
            _studentSocialMediaBusinessRules = studentSocialMediaBusinessRules;
        }

        public async Task<CreatedStudentSocialMediaResponse> Handle(CreateStudentSocialMediaCommand request, CancellationToken cancellationToken)
        {
            StudentSocialMedia studentSocialMedia = _mapper.Map<StudentSocialMedia>(request);
            await _studentSocialMediaBusinessRules.MaxThreeSocialMediaSelections(request.StudentId);
            await _studentSocialMediaBusinessRules.SocialMediaNameCanNotBeDuplicationWhenInserted(request.StudentId,studentSocialMedia);
            await _studentSocialMediaRepository.AddAsync(studentSocialMedia);

            CreatedStudentSocialMediaResponse response = _mapper.Map<CreatedStudentSocialMediaResponse>(studentSocialMedia);
            return response;
        }
    }
}