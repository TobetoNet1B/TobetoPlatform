using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Domain.Entities;

namespace Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<EmailAuthenticator> EmailAuthenticators { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<OtpAuthenticator> OtpAuthenticators { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<Ability> Abilities { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Announcement> Announcements { get; set; }
    public DbSet<Appeal> Appeals { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<CategoryOfModuleSet> Categories { get; set; }
    public DbSet<Certificate> Certificates { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseCategory> CourseCategories { get; set; }
    public DbSet<CourseInstructor> CourseInstructors { get; set; }
    public DbSet<CourseModule> CourseModules { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<Education> Educations { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<LessonTag> LessonTags { get; set; }
    public DbSet<SocialMedia> SocialMedias { get; set; }
    public DbSet<SoftwareLanguage> SoftwareLanguages { get; set; }
    public DbSet<StudentAppeal> StudentAppeals { get; set; }
    public DbSet<StudentExam> StudentExams { get; set; }
    public DbSet<StudentModule> StudentModules { get; set; }
    public DbSet<Survey> Surveys { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<StudentForeignLanguage> StudentForeignLanguages { get; set; }
    public DbSet<ForeignLanguage> ForeignLanguages { get; set; }
    public DbSet<ForeignLanguageLevel> ForeignLanguageLevels { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<ModuleSet> ModuleSets { get; set; }
    public DbSet<Classroom> Classrooms { get; set; }
    public DbSet<StudentClassroom> StudentClassrooms { get; set; }
    public DbSet<CategoryOfCourse> CategoryOfCourses { get; set; }
    public DbSet<CategoryOfModuleSet> CategoryOfModuleSets { get; set; }
    public DbSet<ClassroomModule> ClassroomModules { get; set; }
    public DbSet<ModuleSetCategory> ModuleSetCategories { get; set; }
    public DbSet<ModuleType> ModuleTypes { get; set; }
    public DbSet<Speaker> Speakers { get; set; }
    public DbSet<StudentSocialMedia> StudentSocialMedias { get; set; }
    public DbSet<StudentLesson> StudentLessons { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration)
        : base(dbContextOptions)
    {
        Configuration = configuration;
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}
