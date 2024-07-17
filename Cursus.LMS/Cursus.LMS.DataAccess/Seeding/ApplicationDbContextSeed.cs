using Cursus.LMS.Model.Domain;
using Cursus.LMS.Utility.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Cursus.LMS.DataAccess.Seeding;

public static class ApplicationDbContextSeed
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="modelBuilder"></param>
    public static void SeedEmailTemplate(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmailTemplate>().HasData(
            new
            {
                Id = Guid.NewGuid(),
                TemplateName = "WelcomeEmail",
                SenderName = "Cursus Team",
                SenderEmail = "cursusservicetts@gmail.com",
                Category = "Welcome",
                SubjectLine = "Welcome to Cursus!",
                PreHeaderText = "Thank you for signing up!",
                PersonalizationTags = "{FirstName}, {LastName}",
                BodyContent =
                    "Dear [UserFullName],<br><br>Welcome to Cursus! We are excited to have you join our learning community.",
                FooterContent = "<p>Contact us at cursusservicetts@gmail.com</p>",
                CallToAction = "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>",
                Language = "English",
                RecipientType = "Customer",
                CreateBy = "System",
                CreateTime = DateTime.Now,
                UpdateBy = "Admin",
                UpdateTime = DateTime.Now,
                Status = 1
            },
            new
            {
                Id = Guid.NewGuid(),
                TemplateName = "ForgotPasswordEmail",
                SenderName = "Cursus Team",
                SenderEmail = "cursusservicetts@gmail.com",
                Category = "Security",
                SubjectLine = "Reset Your Password",
                PreHeaderText = "Reset your password to regain access",
                PersonalizationTags = "[UserFullName], [ResetPasswordLink]",
                BodyContent =
                    "Hi [UserFullName],<br><br>We received a request to reset your password. Click the link below to reset your password.",
                FooterContent = "If you did not request a password reset, please ignore this email.",
                CallToAction =
                    $"https://cursuslms.xyz/sign-in/verify-email?userId=user.Id&token=Uri.EscapeDataString(token)",
                Language = "English",
                RecipientType = "Customer",
                CreateBy = "System",
                CreateTime = DateTime.Now,
                UpdateBy = "Admin",
                UpdateTime = DateTime.Now,
                Status = 1
            },
            new
            {
                Id = Guid.NewGuid(),
                TemplateName = "SendVerifyEmail",
                SenderName = "Cursus Team",
                SenderEmail = "cursusservicetts@gmail.com",
                Category = "Verify",
                SubjectLine = "Cursus Verify Email",
                PreHeaderText = "User Account Verified!",
                PersonalizationTags = "{FirstName}, {LinkLogin}",
                BodyContent = "<p>Thank you for registering your Cursus account. Click here to go back the page</p>",
                FooterContent = "<p>Contact us at cursusservicetts@gmail.com</p>",
                CallToAction = "<a href=\"{{Login}}\">Login now</a>",
                Language = "English",
                RecipientType = "Customer",
                CreateBy = "System",
                CreateTime = DateTime.Now,
                UpdateBy = "Admin",
                UpdateTime = DateTime.Now,
                Status = 1
            },
            new
            {
                Id = Guid.NewGuid(),
                TemplateName = "SendEmailForInstructorApproval",
                SenderName = "Cursus Team",
                SenderEmail = "cursusservicetts@gmail.com",
                Category = "Approval",
                SubjectLine = "Circus Verify Email For Instructor Approval",
                PreHeaderText = "Circus Verify Email For Instructor Approval",
                PersonalizationTags = "{FirstName}, {LastName}",
                BodyContent = "<h2>-Your Account has been aprroval!</h2>",
                FooterContent = "<p>Thank you for your waiting! Click this to go to the main page</p>",
                CallToAction =
                    $"<p><a href='http://bloodmoonrpg.carrd.co?token={{token}}' style='padding: 10px 20px; color: white; background-color: #007BFF; text-decoration: none;'>Verify</a></p>",
                Language = "English",
                RecipientType = "Instructor",
                CreateBy = "System",
                CreateTime = DateTime.Now,
                UpdateBy = "Admin",
                UpdateTime = DateTime.Now,
                Status = 1
            },
            new
            {
                Id = Guid.NewGuid(),
                TemplateName = "ChangePassword",
                SenderName = "Cursus Team",
                SenderEmail = "cursusservicetts@gmail.com",
                Category = "Security",
                SubjectLine = "Reset Your Password",
                PreHeaderText = "Reset your password to regain access.",
                PersonalizationTags = "{FirstName}, {ResetLink}",
                BodyContent =
                    "<p>Hello {FirstName},</p><p>Click <a href=\"{ResetLink}\">here</a> to reset your password.</p>",
                FooterContent = "<p>Contact us at cursusservicetts@gmail.com</p>",
                CallToAction = "<a href=\"{{ResetLink}}\">Reset Password</a>",
                Language = "English",
                RecipientType = "Customer",
                CreateBy = "System",
                CreateTime = DateTime.Now,
                UpdateBy = "Admin",
                UpdateTime = DateTime.Now,
                Status = 1
            },
            new
            {
                Id = Guid.NewGuid(),
                TemplateName = "InactiveCourseEmail",
                SenderName = "Instructor",
                SenderEmail = "instructor@gmail.com",
                Category = "Notification",
                SubjectLine = "Inactive Course",
                PreHeaderText = "Hello friends,",
                PersonalizationTags = "{FullName}",
                BodyContent = "<p>Your {courseTitle} course led by {instructorName} is inactive.</p>",
                FooterContent = "<p>Contact us at cursusservicetts@gmail.com</p>",
                CallToAction = "<a href=\"{{LoginLink}}\">Login Now</a>",
                Language = "English",
                RecipientType = "Customer",
                CreateBy = "System",
                CreateTime = DateTime.Now,
                UpdateBy = "Admin",
                UpdateTime = DateTime.Now,
                Status = 1
            },
            new
            {
                Id = Guid.NewGuid(),
                TemplateName = "NotificationForAdminAboutNewCourse",
                SenderName = "Cursus Team",
                SenderEmail = "cursusservicetts@gmail.com",
                Category = "Notice for admin",
                SubjectLine = "New course has been created!",
                PreHeaderText = "The New Courses is available",
                PersonalizationTags = "{FirstName}, {LastName}",
                BodyContent = "New course has been added by Instructor, please check in the main page.",
                FooterContent = "<p>Contact us at cursusservicetts@gmail.com</p>",
                CallToAction = "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>",
                Language = "English",
                RecipientType = "Admin",
                CreateBy = "System",
                CreateTime = DateTime.Now,
                UpdateBy = "Admin",
                UpdateTime = DateTime.Now,
                Status = 1
            },
            new
            {
                Id = Guid.NewGuid(),
                TemplateName = "ApproveInstructorCourse",
                SenderName = "Cursus Team",
                SenderEmail = "cursusservicetts@gmail.com",
                Category = "Notice for instructor",
                SubjectLine = "Your course has been approved!",
                PreHeaderText = "The New Courses is available now",
                PersonalizationTags = "{FirstName}, {LastName}",
                BodyContent = "New course has been approved by Admin, please check in the main page.",
                FooterContent = "<p>Contact us at cursusservicetts@gmail.com</p>",
                CallToAction = "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>",
                Language = "English",
                RecipientType = "Instructor",
                CreateBy = "System",
                CreateTime = DateTime.Now,
                UpdateBy = "Admin",
                UpdateTime = DateTime.Now,
                Status = 1
            },
            new
            {
                Id = Guid.NewGuid(),
                TemplateName = "RejectInstructorCourse",
                SenderName = "Cursus Team",
                SenderEmail = "cursusservicetts@gmail.com",
                Category = "Notice for instructor",
                SubjectLine = "Your course has been rejected!",
                PreHeaderText = "The New Courses is not available now",
                PersonalizationTags = "{FirstName}, {LastName}",
                BodyContent = "New course has been rejected by Admin, please check in the main page.",
                FooterContent = "<p>Contact us at cursusservicetts@gmail.com</p>",
                CallToAction = "<a href=\"https://cursuslms.xyz/user/sign-in\">Login</a>",
                Language = "English",
                RecipientType = "Instructor",
                CreateBy = "System",
                CreateTime = DateTime.Now,
                UpdateBy = "Admin",
                UpdateTime = DateTime.Now,
                Status = 1
            }
        );
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="modelBuilder"></param>
    public static void SeedAdminAccount(ModelBuilder modelBuilder)
    {
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
}