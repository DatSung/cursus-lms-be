using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.IRepository;

public interface ICourseProgressRepository : IRepository<CourseProgress>
{
    void Update(CourseProgress courseProgress);
    void UpdateRange(IEnumerable<CourseProgress> courseProgresses);
}