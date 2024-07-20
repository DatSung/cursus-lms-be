using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.IRepository;

public interface ICourseBookmarkRepository : IRepository<CourseBookmark>
{
    void Update(CourseBookmark courseBookmark);
    void UpdateRange(IEnumerable<CourseBookmark> courseBookmarks);
}