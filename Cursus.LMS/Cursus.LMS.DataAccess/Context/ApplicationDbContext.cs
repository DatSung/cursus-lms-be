using Cursus.LMS.Model.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cursus.LMS.DataAccess.Context;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
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
    
}