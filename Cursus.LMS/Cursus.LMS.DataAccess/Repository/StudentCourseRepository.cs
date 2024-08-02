using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.Repository;

public class StudentCourseRepository : Repository<StudentCourse>, IStudentCourseRepository
{
    private readonly ApplicationDbContext _context;

    public StudentCourseRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(StudentCourse studentCourse)
    {
        _context.StudentCourses.Update(studentCourse);
    }

    public void UpdateRange(IEnumerable<StudentCourse> studentCourses)
    {
        _context.StudentCourses.UpdateRange(studentCourses);
    }
}