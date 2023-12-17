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
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
        services.AddScoped<IAppealRepository, AppealRepository>();
        services.AddScoped<IBlogRepository, BlogRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICertificateRepository, CertificateRepository>();
        services.AddScoped<ICityRepository, CityRepository>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<ICourseCategoryRepository, CourseCategoryRepository>();
        services.AddScoped<ICourseInstructorRepository, CourseInstructorRepository>();
        services.AddScoped<ICourseModuleRepository, CourseModuleRepository>();
        services.AddScoped<IDistrictRepository, DistrictRepository>();
        services.AddScoped<IEducationRepository, EducationRepository>();
        services.AddScoped<IExamRepository, ExamRepository>();
        services.AddScoped<IExperienceRepository, ExperienceRepository>();
        services.AddScoped<IInstructorRepository, InstructorRepository>();
        services.AddScoped<ILessonRepository, LessonRepository>();
        services.AddScoped<ILessonTagRepository, LessonTagRepository>();
        services.AddScoped<ISocialMediaRepository, SocialMediaRepository>();
        services.AddScoped<ISoftwareLanguageRepository, SoftwareLanguageRepository>();
        services.AddScoped<IStudentAppealRepository, StudentAppealRepository>();
        services.AddScoped<IStudentExamRepository, StudentExamRepository>();
        services.AddScoped<IStudentModuleRepository, StudentModuleRepository>();
        services.AddScoped<ISurveyRepository, SurveyRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
        services.AddScoped<IStudentForeignLanguageRepository, StudentForeignLanguageRepository>();
        services.AddScoped<IForeignLanguageRepository, ForeignLanguageRepository>();
        services.AddScoped<IForeignLanguageLevelRepository, ForeignLanguageLevelRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IModuleSetRepository, ModuleSetRepository>();
        services.AddScoped<IClassroomRepository, ClassroomRepository>();
        services.AddScoped<IStudentClassroomRepository, StudentClassroomRepository>();
        return services;
    }
}
