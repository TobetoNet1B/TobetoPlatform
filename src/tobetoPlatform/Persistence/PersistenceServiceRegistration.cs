using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options => options.UseInMemoryDatabase("nArchitecture"));
        services.AddScoped<IEmailAuthenticatorRepository, EmailAuthenticatorRepository>();
        services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
        services.AddScoped<IOtpAuthenticatorRepository, OtpAuthenticatorRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();

        services.AddScoped<IAbilityRepository, AbilityRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
        services.AddScoped<IAppealRepository, AppealRepository>();
        services.AddScoped<IBlogRepository, BlogRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICertificateRepository, CertificateRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<IEducationRepository, EducationRepository>();
        services.AddScoped<IExamRepository, ExamRepository>();
        services.AddScoped<IExperienceRepository, ExperienceRepository>();
        services.AddScoped<IForeignLanguageRepository, ForeignLanguageRepository>();
        services.AddScoped<IForeignLanguageLevelRepository, ForeignLanguageLevelRepository>();
        services.AddScoped<IInstructorRepository, InstructorRepository>();
        services.AddScoped<ISocialMediaRepository, SocialMediaRepository>();
        services.AddScoped<ISurveyRepository, SurveyRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
        services.AddScoped<ICourseCategoryRepository, CourseCategoryRepository>();
        services.AddScoped<ICourseInstructorRepository, CourseInstructorRepository>();
        services.AddScoped<ICourseStudentRepository, CourseStudentRepository>();
        services.AddScoped<IStudentExamRepository, StudentExamRepository>();
        return services;
    }
}
