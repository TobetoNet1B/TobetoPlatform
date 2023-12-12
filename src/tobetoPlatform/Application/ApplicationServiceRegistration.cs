using Application.Services.AuthenticatorService;
using Application.Services.AuthService;
using Application.Services.UsersService;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Core.Application.Pipelines.Validation;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Logging.Serilog;
using Core.CrossCuttingConcerns.Logging.Serilog.Logger;
using Core.ElasticSearch;
using Core.Mailing;
using Core.Mailing.MailKitImplementations;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Application.Services.Abilities;
using Application.Services.Students;
using Application.Services.Announcements;
using Application.Services.Appeals;
using Application.Services.Blogs;
using Application.Services.Categories;
using Application.Services.Certificates;
using Application.Services.Courses;
using Application.Services.Educations;
using Application.Services.Exams;
using Application.Services.Experiences;
using Application.Services.ForeignLanguages;
using Application.Services.ForeignLanguageLevels;
using Application.Services.Instructors;
using Application.Services.SocialMedias;
using Application.Services.Surveys;
using Application.Services.Tags;
using Application.Services.CourseCategories;
using Application.Services.CourseInstructors;
using Application.Services.CourseStudents;
using Application.Services.StudentExams;

namespace Application;
public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            configuration.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
            configuration.AddOpenBehavior(typeof(CachingBehavior<,>));
            configuration.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));
            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
            configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
            configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));
        });

        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddSingleton<IMailService, MailKitMailService>();
        services.AddSingleton<LoggerServiceBase, FileLogger>();
        services.AddSingleton<IElasticSearch, ElasticSearchManager>();
        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<IAuthenticatorService, AuthenticatorManager>();
        services.AddScoped<IUserService, UserManager>();

        services.AddScoped<IAbilitiesService, AbilitiesManager>();
        services.AddScoped<IStudentsService, StudentsManager>();
        services.AddScoped<IAnnouncementsService, AnnouncementsManager>();
        services.AddScoped<IAppealsService, AppealsManager>();
        services.AddScoped<IBlogsService, BlogsManager>();
        services.AddScoped<ICategoriesService, CategoriesManager>();
        services.AddScoped<ICertificatesService, CertificatesManager>();
        services.AddScoped<ICoursesService, CoursesManager>();
        services.AddScoped<IEducationsService, EducationsManager>();
        services.AddScoped<IExamsService, ExamsManager>();
        services.AddScoped<IExperiencesService, ExperiencesManager>();
        services.AddScoped<IForeignLanguagesService, ForeignLanguagesManager>();
        services.AddScoped<IForeignLanguageLevelsService, ForeignLanguageLevelsManager>();
        services.AddScoped<IInstructorsService, InstructorsManager>();
        services.AddScoped<ISocialMediasService, SocialMediasManager>();
        services.AddScoped<ISurveysService, SurveysManager>();
        services.AddScoped<ITagsService, TagsManager>();
        services.AddScoped<ICourseCategoriesService, CourseCategoriesManager>();
        services.AddScoped<ICourseInstructorsService, CourseInstructorsManager>();
        services.AddScoped<ICourseStudentsService, CourseStudentsManager>();
        services.AddScoped<IStudentExamsService, StudentExamsManager>();
        return services;
    }

    public static IServiceCollection AddSubClassesOfType(
        this IServiceCollection services,
        Assembly assembly,
        Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
    )
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (Type? item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);
            else
                addWithLifeCycle(services, type);
        return services;
    }
}
