using Application.Features.Certificates.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Certificates.Rules;

public class CertificateBusinessRules : BaseBusinessRules
{
    private readonly ICertificateRepository _certificateRepository;

    public CertificateBusinessRules(ICertificateRepository certificateRepository)
    {
        _certificateRepository = certificateRepository;
    }

    public Task CertificateShouldExistWhenSelected(Certificate? certificate)
    {
        if (certificate == null)
            throw new BusinessException(CertificatesBusinessMessages.CertificateNotExists);
        return Task.CompletedTask;
    }

    public async Task CertificateIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Certificate? certificate = await _certificateRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CertificateShouldExistWhenSelected(certificate);
    }

    public async Task CertificateNameCanNotBeDuplicationWhenInserted(Guid id, Certificate certificate)
    {
        IPaginate<Certificate> result = await _certificateRepository.GetListAsync(s => s.StudentId == id);
        if (result.Items.Any(c => c.Name == certificate.Name))
        {
            throw new BusinessException(CertificatesBusinessMessages.CertificateNameExists);
        }

    }



}