using Cursus.LMS.Model.Domain;
using Cursus.LMS.Utility.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Cursus.LMS.DataAccess.Seeding;

namespace Cursus.LMS.DataAccess.Context;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ApplicationDbContextSeed.SeedAdminAccount(modelBuilder);
        ApplicationDbContextSeed.SeedEmailTemplate(modelBuilder);
    }

    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<CartDetails> CartDetails { get; set; }
    public DbSet<CartHeader> CartHeaders { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseReport> CourseReports { get; set; }
    public DbSet<CourseReview> CourseReviews { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Level> Levels { get; set; }
    public DbSet<OrderDetails> OrderDetails { get; set; }
    public DbSet<OrderHeader> OrderHeaders { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<StudentCourse> StudentCourses { get; set; }
    public DbSet<PaymentCard> PaymentCards { get; set; }
    public DbSet<InstructorComment> InstructorComments { get; set; }
    public DbSet<InstructorRating> InstructorRatings { get; set; }
    public DbSet<EmailTemplate> EmailTemplates { get; set; }
    public DbSet<CourseVersion> CourseVersions { get; set; }
    public DbSet<CourseSectionVersion> CourseSectionVersions { get; set; }
    public DbSet<SectionDetailsVersion> SectionDetailsVersions { get; set; }
    public DbSet<CourseVersionStatus> CourseVersionStatus { get; set; }
    public DbSet<CourseVersionComment> CourseVersionComments { get; set; }
    public DbSet<StudentComment> StudentComments { get; set; }
}