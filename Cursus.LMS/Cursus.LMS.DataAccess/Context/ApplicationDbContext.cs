using Cursus.LMS.Model.Domain;
using Cursus.LMS.Utility.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Cursus.LMS.DataAccess.Context;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var studentRoleId = "8fa7c7bb-b4dc-480d-a660-e07a90855d5d";
        var instructorRoleId = "35446074-daa5-4973-bf02-82301a5eb327";
        var adminRoleId = "8fa7c7bb-daa5-a660-bf02-82301a5eb327"; // Add admin role

        var roles = new List<IdentityRole>
        {
            new IdentityRole
            {
                Id = studentRoleId,
                ConcurrencyStamp = StaticUserRoles.Student,
                Name = StaticUserRoles.Student,
                NormalizedName = StaticUserRoles.Student,
            },
            new IdentityRole
            {
                Id = instructorRoleId,
                ConcurrencyStamp = StaticUserRoles.Instructor,
                Name = StaticUserRoles.Instructor,
                NormalizedName = StaticUserRoles.Instructor,
            },
            new IdentityRole
            {
                Id = adminRoleId,
                ConcurrencyStamp = StaticUserRoles.Admin,
                Name = StaticUserRoles.Admin,
                NormalizedName = StaticUserRoles.Admin,
            }
        };

        modelBuilder.Entity<IdentityRole>().HasData(roles);

        // Seeding admin user
        var adminUserId = "BestZedAndYasuo";
        var hasher = new PasswordHasher<ApplicationUser>();
        var adminUser = new ApplicationUser
        {
            Id = adminUserId,
            Gender = "Male", // Set appropriate value
            FullName = "Admin User",
            BirthDate = new DateTime(1990, 1, 1), // Set appropriate value
            AvatarUrl = "https://example.com/avatar.png", // Set appropriate value
            Country = "Country", // Set appropriate value
            Address = "123 Admin St",
            TaxNumber = "123456789",
            UserName = "admin@gmail.com",
            NormalizedUserName = "ADMIN@GMAIL.COM",
            Email = "admin@gmail.com",
            NormalizedEmail = "ADMIN@GMAIL.COM",
            EmailConfirmed = true,
            PasswordHash = hasher.HashPassword(null, "Admin123!"),
            SecurityStamp = Guid.NewGuid().ToString(),
            ConcurrencyStamp = Guid.NewGuid().ToString(),
            PhoneNumber = "1234567890",
            PhoneNumberConfirmed = true,
            TwoFactorEnabled = false,
            LockoutEnd = null,
            LockoutEnabled = true,
            AccessFailedCount = 0,
            UpdateTime = new DateTime(2003, 1, 12)
        };

        modelBuilder.Entity<ApplicationUser>().HasData(adminUser);

        // Assigning the admin role to the admin user
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = adminRoleId,
            UserId = adminUserId
        });
    }

    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<CartDetails> CartDetails { get; set; }
    public DbSet<CartHeader> CartHeaders { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseReport> CourseReports { get; set; }
    public DbSet<CourseReview> CourseReviews { get; set; }
    public DbSet<CourseSection> CourseSections { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Level> Levels { get; set; }
    public DbSet<OrderDetails> OrderDetails { get; set; }
    public DbSet<OrderHeader> OrderHeaders { get; set; }
    public DbSet<SectionDetails> SectionDetails { get; set; }
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
    // public DbSet<CourseSectionVersionStatus> CourseSectionVersionStatus { get; set; }
    // public DbSet<SectionDetailsVersionStatus> SectionDetailsVersionStatus { get; set; }
    public DbSet<CourseVersionComment> CourseVersionComments { get; set; }
}