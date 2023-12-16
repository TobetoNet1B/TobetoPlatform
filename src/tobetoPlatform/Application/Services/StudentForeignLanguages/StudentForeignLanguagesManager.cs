using Application.Features.StudentForeignLanguages.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.StudentForeignLanguages;

public class StudentForeignLanguagesManager : IStudentForeignLanguagesService
{
    private readonly IStudentForeignLanguageRepository _studentForeignLanguageRepository;
    private readonly StudentForeignLanguageBusinessRules _studentForeignLanguageBusinessRules;

    public StudentForeignLanguagesManager(IStudentForeignLanguageRepository studentForeignLanguageRepository, StudentForeignLanguageBusinessRules studentForeignLanguageBusinessRules)
    {
        _studentForeignLanguageRepository = studentForeignLanguageRepository;
        _studentForeignLanguageBusinessRules = studentForeignLanguageBusinessRules;
    }

    public async Task<StudentForeignLanguage?> GetAsync(
        Expression<Func<StudentForeignLanguage, bool>> predicate,
        Func<IQueryable<StudentForeignLanguage>, IIncludableQueryable<StudentForeignLanguage, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        StudentForeignLanguage? studentForeignLanguage = await _studentForeignLanguageRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return studentForeignLanguage;
    }

    public async Task<IPaginate<StudentForeignLanguage>?> GetListAsync(
        Expression<Func<StudentForeignLanguage, bool>>? predicate = null,
        Func<IQueryable<StudentForeignLanguage>, IOrderedQueryable<StudentForeignLanguage>>? orderBy = null,
        Func<IQueryable<StudentForeignLanguage>, IIncludableQueryable<StudentForeignLanguage, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<StudentForeignLanguage> studentForeignLanguageList = await _studentForeignLanguageRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return studentForeignLanguageList;
    }

    public async Task<StudentForeignLanguage> AddAsync(StudentForeignLanguage studentForeignLanguage)
    {
        StudentForeignLanguage addedStudentForeignLanguage = await _studentForeignLanguageRepository.AddAsync(studentForeignLanguage);

        return addedStudentForeignLanguage;
    }

    public async Task<StudentForeignLanguage> UpdateAsync(StudentForeignLanguage studentForeignLanguage)
    {
        StudentForeignLanguage updatedStudentForeignLanguage = await _studentForeignLanguageRepository.UpdateAsync(studentForeignLanguage);

        return updatedStudentForeignLanguage;
    }

    public async Task<StudentForeignLanguage> DeleteAsync(StudentForeignLanguage studentForeignLanguage, bool permanent = false)
    {
        StudentForeignLanguage deletedStudentForeignLanguage = await _studentForeignLanguageRepository.DeleteAsync(studentForeignLanguage);

        return deletedStudentForeignLanguage;
    }
}
