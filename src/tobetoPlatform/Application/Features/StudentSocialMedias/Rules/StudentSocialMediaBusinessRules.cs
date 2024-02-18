using Application.Features.StudentSocialMedias.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.StudentSocialMedias.Rules;

public class StudentSocialMediaBusinessRules : BaseBusinessRules
{
    private readonly IStudentSocialMediaRepository _studentSocialMediaRepository;

    public static string? SocialMediaNameExists { get; private set; }

    public StudentSocialMediaBusinessRules(IStudentSocialMediaRepository studentSocialMediaRepository)
    {
        _studentSocialMediaRepository = studentSocialMediaRepository;
    }

    public Task StudentSocialMediaShouldExistWhenSelected(StudentSocialMedia? studentSocialMedia)
    {
        if (studentSocialMedia == null)
            throw new BusinessException(StudentSocialMediasBusinessMessages.StudentSocialMediaNotExists);
        return Task.CompletedTask;
    }

    public async Task StudentSocialMediaIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        StudentSocialMedia? studentSocialMedia = await _studentSocialMediaRepository.GetAsync(
            predicate: ssm => ssm.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await StudentSocialMediaShouldExistWhenSelected(studentSocialMedia);
    }
    public async Task MaxThreeSocialMediaSelections(Guid id)
    {
        IPaginate<StudentSocialMedia> result = await _studentSocialMediaRepository.GetListAsync(s => s.StudentId == id);
        if (result.Count >= SocialMediasRuleTypes.SocialMediaLimit)
        {
            throw new BusinessException(StudentSocialMediasBusinessMessages.SocialMediaLimit); 
        }
    }

    public async Task SocialMediaNameCanNotBeDuplicationWhenInserted(Guid id, StudentSocialMedia socialMedia)
    {
        IPaginate<StudentSocialMedia> result = await _studentSocialMediaRepository.GetListAsync(s => s.StudentId == id);
        if (result.Items.Any(existingSocialMedia => existingSocialMedia.SocialMediaUrl == socialMedia.SocialMediaUrl))
        {
            throw new BusinessException(StudentSocialMediasBusinessMessages.SocialMediaNameExists);
        }
    }
}