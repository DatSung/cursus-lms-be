using Cursus.LMS.DataAccess.Context;
using Cursus.LMS.DataAccess.IRepository;
using Cursus.LMS.Model.Domain;

namespace Cursus.LMS.DataAccess.Repository;

public class CourseVersionRepository : Repository<CourseVersion>, ICourseVersionRepository
{
    private readonly ApplicationDbContext _context;
    
    public CourseVersionRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(CourseVersion courseVersion)
    {
        _context.CourseVersions.Update(courseVersion);
    }

    public void UpdateRange(IEnumerable<CourseVersion> courseVersions)
    {
        _context.CourseVersions.UpdateRange(courseVersions);
    }
}