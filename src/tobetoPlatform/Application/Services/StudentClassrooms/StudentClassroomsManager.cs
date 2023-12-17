using Application.Features.StudentClassrooms.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.StudentClassrooms;

public class StudentClassroomsManager : IStudentClassroomsService
{
    private readonly IStudentClassroomRepository _studentClassroomRepository;
    private readonly StudentClassroomBusinessRules _studentClassroomBusinessRules;

    public StudentClassroomsManager(IStudentClassroomRepository studentClassroomRepository, StudentClassroomBusinessRules studentClassroomBusinessRules)
    {
        _studentClassroomRepository = studentClassroomRepository;
        _studentClassroomBusinessRules = studentClassroomBusinessRules;
    }

    public async Task<StudentClassroom?> GetAsync(
        Expression<Func<StudentClassroom, bool>> predicate,
        Func<IQueryable<StudentClassroom>, IIncludableQueryable<StudentClassroom, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        StudentClassroom? studentClassroom = await _studentClassroomRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return studentClassroom;
    }

    public async Task<IPaginate<StudentClassroom>?> GetListAsync(
        Expression<Func<StudentClassroom, bool>>? predicate = null,
        Func<IQueryable<StudentClassroom>, IOrderedQueryable<StudentClassroom>>? orderBy = null,
        Func<IQueryable<StudentClassroom>, IIncludableQueryable<StudentClassroom, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<StudentClassroom> studentClassroomList = await _studentClassroomRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return studentClassroomList;
    }

    public async Task<StudentClassroom> AddAsync(StudentClassroom studentClassroom)
    {
        StudentClassroom addedStudentClassroom = await _studentClassroomRepository.AddAsync(studentClassroom);

        return addedStudentClassroom;
    }

    public async Task<StudentClassroom> UpdateAsync(StudentClassroom studentClassroom)
    {
        StudentClassroom updatedStudentClassroom = await _studentClassroomRepository.UpdateAsync(studentClassroom);

        return updatedStudentClassroom;
    }

    public async Task<StudentClassroom> DeleteAsync(StudentClassroom studentClassroom, bool permanent = false)
    {
        StudentClassroom deletedStudentClassroom = await _studentClassroomRepository.DeleteAsync(studentClassroom);

        return deletedStudentClassroom;
    }
}
