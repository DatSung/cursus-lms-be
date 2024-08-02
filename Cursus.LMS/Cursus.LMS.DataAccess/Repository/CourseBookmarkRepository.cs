using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.Repository;

public class CourseBookmarkRepository : Repository<CourseBookmark>, ICourseBookmarkRepository
{
    private readonly ApplicationDbContext _context;

    public CourseBookmarkRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(CourseBookmark courseBookmark)
    {
        _context.CourseBookmarks.Update(courseBookmark);
    }

    public void UpdateRange(IEnumerable<CourseBookmark> courseBookmarks)
    {
        _context.CourseBookmarks.UpdateRange(courseBookmarks);
    }
}