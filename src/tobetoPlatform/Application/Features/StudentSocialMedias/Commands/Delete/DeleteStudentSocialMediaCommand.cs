using Application.Features.StudentSocialMedias.Constants;
using Application.Features.StudentSocialMedias.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentSocialMedias.Commands.Delete;

public class DeleteStudentSocialMediaCommand : IRequest<DeletedStudentSocialMediaResponse>
{
    public Guid Id { get; set; }

    public class DeleteStudentSocialMediaCommandHandler : IRequestHandler<DeleteStudentSocialMediaCommand, DeletedStudentSocialMediaResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentSocialMediaRepository _studentSocialMediaRepository;
        private readonly StudentSocialMediaBusinessRules _studentSocialMediaBusinessRules;

        public DeleteStudentSocialMediaCommandHandler(IMapper mapper, IStudentSocialMediaRepository studentSocialMediaRepository,
                                         StudentSocialMediaBusinessRules studentSocialMediaBusinessRules)
        {
            _mapper = mapper;
            _studentSocialMediaRepository = studentSocialMediaRepository;
            _studentSocialMediaBusinessRules = studentSocialMediaBusinessRules;
        }

        public async Task<DeletedStudentSocialMediaResponse> Handle(DeleteStudentSocialMediaCommand request, CancellationToken cancellationToken)
        {
            StudentSocialMedia? studentSocialMedia = await _studentSocialMediaRepository.GetAsync(predicate: ssm => ssm.Id == request.Id, cancellationToken: cancellationToken);
            await _studentSocialMediaBusinessRules.StudentSocialMediaShouldExistWhenSelected(studentSocialMedia);

            await _studentSocialMediaRepository.DeleteAsync(studentSocialMedia!);

            DeletedStudentSocialMediaResponse response = _mapper.Map<DeletedStudentSocialMediaResponse>(studentSocialMedia);
            return response;
        }
    }
}