using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.Repository;

public class StudentCourseStatusRepository : Repository<StudentCourseStatus>, IStudentCourseStatusRepository
{
    private readonly ApplicationDbContext _context;

    public StudentCourseStatusRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(StudentCourseStatus studentCourseStatus)
    {
        _context.StudentCoursesStatus.Update(studentCourseStatus);
    }

    public void UpdateRange(IEnumerable<StudentCourseStatus> studentCoursesStatus)
    {
        _context.StudentCoursesStatus.UpdateRange(studentCoursesStatus);
    }
}