using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.Repository;

public class CourseProgressRepository : Repository<CourseProgress>, ICourseProgressRepository
{
    private readonly ApplicationDbContext _context;
    
    public CourseProgressRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(CourseProgress courseProgress)
    {
        _context.CourseProgresses.Update(courseProgress);
    }

    public void UpdateRange(IEnumerable<CourseProgress> courseProgresses)
    {
        _context.CourseProgresses.UpdateRange(courseProgresses);
    }
}