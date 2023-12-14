using Application.Features.OperationClaims.Constants;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasMany(oc => oc.UserOperationClaims);

        builder.HasData(getSeeds());
    }

    private HashSet<OperationClaim> getSeeds()
    {
        int id = 0;
        HashSet<OperationClaim> seeds =
            new()
            {
                new OperationClaim { Id = ++id, Name = GeneralOperationClaims.Admin }
            };

        
        #region Abilities
        seeds.Add(new OperationClaim { Id = ++id, Name = "Abilities.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Abilities.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Abilities.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Abilities.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Abilities.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Abilities.Delete" });
        #endregion
        #region Students
        seeds.Add(new OperationClaim { Id = ++id, Name = "Students.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Students.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Students.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Students.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Students.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Students.Delete" });
        #endregion
        #region Announcements
        seeds.Add(new OperationClaim { Id = ++id, Name = "Announcements.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Announcements.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Announcements.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Announcements.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Announcements.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Announcements.Delete" });
        #endregion
        #region Appeals
        seeds.Add(new OperationClaim { Id = ++id, Name = "Appeals.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Appeals.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Appeals.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Appeals.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Appeals.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Appeals.Delete" });
        #endregion
        #region Blogs
        seeds.Add(new OperationClaim { Id = ++id, Name = "Blogs.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Blogs.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Blogs.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Blogs.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Blogs.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Blogs.Delete" });
        #endregion
        #region Categories
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Categories.Delete" });
        #endregion
        #region Certificates
        seeds.Add(new OperationClaim { Id = ++id, Name = "Certificates.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Certificates.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Certificates.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Certificates.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Certificates.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Certificates.Delete" });
        #endregion
        #region Courses
        seeds.Add(new OperationClaim { Id = ++id, Name = "Courses.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Courses.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Courses.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Courses.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Courses.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Courses.Delete" });
        #endregion
        #region Educations
        seeds.Add(new OperationClaim { Id = ++id, Name = "Educations.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Educations.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Educations.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Educations.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Educations.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Educations.Delete" });
        #endregion
        #region Exams
        seeds.Add(new OperationClaim { Id = ++id, Name = "Exams.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Exams.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Exams.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Exams.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Exams.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Exams.Delete" });
        #endregion
        #region Experiences
        seeds.Add(new OperationClaim { Id = ++id, Name = "Experiences.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Experiences.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Experiences.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Experiences.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Experiences.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Experiences.Delete" });
        #endregion
        #region ForeignLanguages
        seeds.Add(new OperationClaim { Id = ++id, Name = "ForeignLanguages.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ForeignLanguages.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ForeignLanguages.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ForeignLanguages.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ForeignLanguages.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ForeignLanguages.Delete" });
        #endregion
        #region ForeignLanguageLevels
        seeds.Add(new OperationClaim { Id = ++id, Name = "ForeignLanguageLevels.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ForeignLanguageLevels.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ForeignLanguageLevels.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ForeignLanguageLevels.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ForeignLanguageLevels.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "ForeignLanguageLevels.Delete" });
        #endregion
        #region Instructors
        seeds.Add(new OperationClaim { Id = ++id, Name = "Instructors.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Instructors.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Instructors.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Instructors.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Instructors.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Instructors.Delete" });
        #endregion
        #region SocialMedias
        seeds.Add(new OperationClaim { Id = ++id, Name = "SocialMedias.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SocialMedias.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SocialMedias.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SocialMedias.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SocialMedias.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SocialMedias.Delete" });
        #endregion
        #region Surveys
        seeds.Add(new OperationClaim { Id = ++id, Name = "Surveys.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Surveys.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Surveys.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Surveys.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Surveys.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Surveys.Delete" });
        #endregion
        #region Tags
        seeds.Add(new OperationClaim { Id = ++id, Name = "Tags.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Tags.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Tags.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Tags.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Tags.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Tags.Delete" });
        #endregion
        #region CourseCategories
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseCategories.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseCategories.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseCategories.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseCategories.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseCategories.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseCategories.Delete" });
        #endregion
        #region CourseInstructors
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseInstructors.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseInstructors.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseInstructors.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseInstructors.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseInstructors.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseInstructors.Delete" });
        #endregion
        #region CourseStudents
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseStudents.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseStudents.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseStudents.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseStudents.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseStudents.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseStudents.Delete" });
        #endregion
        #region StudentExams
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentExams.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentExams.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentExams.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentExams.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentExams.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentExams.Delete" });
        #endregion
        #region Addresses
        seeds.Add(new OperationClaim { Id = ++id, Name = "Addresses.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Addresses.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Addresses.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Addresses.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Addresses.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Addresses.Delete" });
        #endregion
        #region Cities
        seeds.Add(new OperationClaim { Id = ++id, Name = "Cities.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Cities.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Cities.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Cities.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Cities.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Cities.Delete" });
        #endregion
        #region Companies
        seeds.Add(new OperationClaim { Id = ++id, Name = "Companies.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Companies.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Companies.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Companies.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Companies.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Companies.Delete" });
        #endregion
        #region Countries
        seeds.Add(new OperationClaim { Id = ++id, Name = "Countries.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Countries.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Countries.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Countries.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Countries.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Countries.Delete" });
        #endregion
        #region CourseModules
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseModules.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseModules.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseModules.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseModules.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseModules.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CourseModules.Delete" });
        #endregion
        #region Districts
        seeds.Add(new OperationClaim { Id = ++id, Name = "Districts.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Districts.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Districts.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Districts.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Districts.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Districts.Delete" });
        #endregion
        #region Lessons
        seeds.Add(new OperationClaim { Id = ++id, Name = "Lessons.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Lessons.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Lessons.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Lessons.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Lessons.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Lessons.Delete" });
        #endregion
        #region LessonTags
        seeds.Add(new OperationClaim { Id = ++id, Name = "LessonTags.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LessonTags.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LessonTags.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LessonTags.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LessonTags.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "LessonTags.Delete" });
        #endregion
        #region Modules
        seeds.Add(new OperationClaim { Id = ++id, Name = "Modules.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Modules.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Modules.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Modules.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Modules.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Modules.Delete" });
        #endregion
        #region SoftwareLanguages
        seeds.Add(new OperationClaim { Id = ++id, Name = "SoftwareLanguages.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SoftwareLanguages.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SoftwareLanguages.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SoftwareLanguages.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SoftwareLanguages.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "SoftwareLanguages.Delete" });
        #endregion
        #region StudentAppeals
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentAppeals.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentAppeals.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentAppeals.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentAppeals.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentAppeals.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentAppeals.Delete" });
        #endregion
        #region StudentModules
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentModules.Admin" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentModules.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentModules.Write" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentModules.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentModules.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "StudentModules.Delete" });
        #endregion
        return seeds;
    }
}
