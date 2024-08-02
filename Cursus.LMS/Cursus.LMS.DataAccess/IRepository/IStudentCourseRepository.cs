using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.IRepository;

public interface IStudentCourseRepository : IRepository<StudentCourse>
{
    void Update(StudentCourse studentCourse);
    void UpdateRange(IEnumerable<StudentCourse> studentCourses);
}