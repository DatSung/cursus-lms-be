using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.IRepository;

public interface IStudentCourseStatusRepository : IRepository<StudentCourseStatus>
{
    void Update(StudentCourseStatus studentCourseStatus);
    void UpdateRange(IEnumerable<StudentCourseStatus> studentCoursesStatus);
}