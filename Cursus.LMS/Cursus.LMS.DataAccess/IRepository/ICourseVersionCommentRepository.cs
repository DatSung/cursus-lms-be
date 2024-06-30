using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.IRepository;

public interface ICourseVersionCommentRepository : IRepository<CourseVersionComment>
{
    void Update(CourseVersionComment courseVersionComment);
    void UpdateRange(IEnumerable<CourseVersionComment> courseVersionComments);
    Task<CourseVersionComment?> GetCourseVersionCommentById(Guid courseversioncommentId);
}