using Application.Features.StudentForeignLanguages.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.StudentForeignLanguages.Rules;

public class StudentForeignLanguageBusinessRules : BaseBusinessRules
{
    private readonly IStudentForeignLanguageRepository _studentForeignLanguageRepository;

    public StudentForeignLanguageBusinessRules(IStudentForeignLanguageRepository studentForeignLanguageRepository)
    {
        _studentForeignLanguageRepository = studentForeignLanguageRepository;
    }

    public Task StudentForeignLanguageShouldExistWhenSelected(StudentForeignLanguage? studentForeignLanguage)
    {
        if (studentForeignLanguage == null)
            throw new BusinessException(StudentForeignLanguagesBusinessMessages.StudentForeignLanguageNotExists);
        return Task.CompletedTask;
    }

    public async Task StudentForeignLanguageIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        StudentForeignLanguage? studentForeignLanguage = await _studentForeignLanguageRepository.GetAsync(
            predicate: sfl => sfl.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await StudentForeignLanguageShouldExistWhenSelected(studentForeignLanguage);
    }
}